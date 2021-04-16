#version 330

layout (location = 0) in vec4 position;
layout (location = 1) in vec2 texCord;

uniform mat4 proj;
uniform mat4 view;
uniform mat4 model;

uniform vec3 normal;
uniform vec3 tangent;
uniform vec3 bitangent;
uniform vec4 color;

uniform vec3 Light;
uniform vec4 LightColor;

uniform vec3 eye;

out VS_OUT{
    out vec4 FragPos;
    out vec2 TexCord;

    out vec3 TangentLightPos;
    out vec3 TangentViewPos;
    out vec3 TangentFragPos;
} vs_out;

out vec3 Normal;

void main()
{
    vs_out.FragPos =  model * position;
    vs_out.TexCord = texCord;
    
    Normal = normalize(mat3(model) * normal);
    vec3 T = normalize(mat3(model) * tangent);
    vec3 B = normalize(mat3(model) * bitangent);

    mat3 TBN = transpose(mat3(T, B, Normal));

    vs_out.TangentLightPos = TBN * Light;
    vs_out.TangentViewPos = TBN * eye;
    vs_out.TangentFragPos = TBN * vs_out.FragPos.xyz;

    gl_Position = proj * view * model * position;
}