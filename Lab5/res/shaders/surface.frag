#version 330
uniform vec3 normal;
uniform vec4 color;

uniform vec3 Light;
uniform vec4 LightColor;

uniform vec3 eye;

uniform sampler2D diffuseMap;
uniform sampler2D normalMap;
uniform sampler2D depthMap;

uniform int UseParallaxOcclusion;


in VS_OUT {
    in vec3 FragPos;
    in vec2 TexCord;

    in vec3 TangentLightPos;
    in vec3 TangentViewPos;
    in vec3 TangentFragPos;
} fs_in;


float height_scale = 0.05f;

vec2 SimpleParallaxMapping(vec2 texCoords, vec3 viewDir)
{
    float height =  1.0 - texture(depthMap, texCoords).r;    
    vec2 p = viewDir.xy / viewDir.z * (height * height_scale);
    return texCoords - p;  
}

vec2 ParallaxMapping(vec2 texCoords, vec3 viewDir)
{
    // number of depth layers
    const float minLayers = 8;
    const float maxLayers = 128;
    float numLayers = mix(maxLayers, minLayers, abs(dot(vec3(0.0, 0.0, 1.0), viewDir)));  
    // calculate the size of each layer
    float layerDepth = 1.0 / numLayers;
    // depth of current layer
    float currentLayerDepth = 0.0;
    // the amount to shift the texture coordinates per layer (from vector P)
    vec2 P = viewDir.xy / viewDir.z * height_scale; 
    vec2 deltaTexCoords = P / numLayers;
  
    // get initial values
    vec2  currentTexCoords     = texCoords;
    float currentDepthMapValue = 1.0 - texture(depthMap, currentTexCoords).r;
      
    while(currentLayerDepth < currentDepthMapValue)
    {
        // shift texture coordinates along direction of P
        currentTexCoords -= deltaTexCoords;
        // get depthmap value at current texture coordinates
        currentDepthMapValue = 1.0 - texture(depthMap, currentTexCoords).r;  
        // get depth of next layer
        currentLayerDepth += layerDepth;  
    }
    
    // get texture coordinates before collision (reverse operations)
    vec2 prevTexCoords = currentTexCoords + deltaTexCoords;

    // get depth after and before collision for linear interpolation
    float afterDepth  = currentDepthMapValue - currentLayerDepth;
    float beforeDepth = 1.0 - texture(depthMap, prevTexCoords).r - currentLayerDepth + layerDepth;
 
    // interpolation of texture coordinates
    float weight = afterDepth / (afterDepth - beforeDepth); 
    vec2 finalTexCoords = prevTexCoords * weight + currentTexCoords * (1.0 - weight);

    return finalTexCoords;
}


void main()
{
    vec3 view_dir = normalize(fs_in.TangentViewPos - fs_in.TangentFragPos);
    vec2 tex_cords = fs_in.TexCord;

    if(UseParallaxOcclusion == 1)
    {
        tex_cords = ParallaxMapping(fs_in.TexCord, view_dir);
    }
    if(tex_cords.x > 1.0 || tex_cords.y > 1.0 || tex_cords.x < 0.0 || tex_cords.y < 0.0)
        discard;

    vec3 normal = texture(normalMap, tex_cords).rgb;
    normal = normalize(normal * 2.0 - 1.0);

    // get diffuse color
    vec4 texture_color = texture(diffuseMap, tex_cords);

    // ambient
    float ambient_strength = 0.1;
    vec4 ambient = ambient_strength * texture_color;
  	
    // diffuse 
    vec3 light_dir = normalize(fs_in.TangentLightPos - fs_in.TangentFragPos);
    float diff = max(dot(normal, light_dir), 0.0);
    vec4 diffuse = diff * texture_color;
    
    // specular
    float specular_strength = 0.5;
    vec3 reflect_dir = reflect(-light_dir, normal);
    vec3 halfway_dir = normalize(light_dir + view_dir);
    float spec = pow(max(dot(normal, halfway_dir), 0.0), 256); // halfway_dir may be changed to view_dir
    vec4 specular = specular_strength * spec * texture_color;

    vec4 result = ambient + diffuse + specular;

    gl_FragColor = result;
}