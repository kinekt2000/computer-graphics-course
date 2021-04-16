#include "glad/glad.h"
#include <GLFW/glfw3.h>

#include <iostream>

#include <glm/matrix.hpp>
#include <glm/gtc/matrix_transform.hpp>

#include "VertexBufferObject.h"
#include "VertexArrayObject.h"
#include "VertexBufferLayout.h"
#include "ElementBufferObject.h"
#include "Texture.h"
#include "Shader.h"


#define INITIAL_WIDTH 640
#define INITIAL_HEIGHT 480

#define MOUSE_SENSITIVITY_X 1
#define MOUSE_SENSITIVITY_Y 1


static void MouseButtonCallback(GLFWwindow* window, int button, int action, int mods);
static void ScrollCallback(GLFWwindow* window, double xoffset, double yoffset);
static void CursorPositionCallback(GLFWwindow* window, double xpos, double ypos);
static void CursorEnterCallback(GLFWwindow* window, int entered);
static void KeyCallback(GLFWwindow* window, int key, int scancode, int action, int mods);
static void FrameBufferSizeCallback(GLFWwindow* window, int xscale, int yscale);

bool b_MouseOutOfWindow = true;
bool b_HandleMouse = true;
bool b_RotationMode = false;

// Camera settings
glm::vec3 CameraPosition = glm::vec3(0, 0, 2);
glm::vec3 EyeSight = glm::vec3(0, 0, 0);
glm::vec3 CameraHead = glm::vec3(0, 1, 0);

// Projection settings
int Width = INITIAL_WIDTH;
int Height = INITIAL_HEIGHT;
float ScreenRatio = (float)Width / (float)Height;

// Surface settings
glm::vec3 position = glm::vec3(0, 0, 0);
glm::mat4 rotation = glm::mat4(1.f);
glm::vec3 scale = glm::vec3(1, 1, 1);
glm::vec3 normal = glm::vec3(0, 0, 1);
glm::vec3 tangent = glm::vec3(1, 0, 0);
glm::vec3 bitangent = glm::vec3(0, 1, 0);

// Light settings
glm::vec3 LightPosition = glm::vec3(-1.f, 1.f, 1.f);
glm::vec4 LightColor = glm::vec4(1, 1, 1, 1);

glm::mat4 model = glm::mat4(1.0f);

// Parallax Occlusion
bool UseParallaxOcclusion = false;



int main(void)
{
    GLFWwindow* window;

    /* Initialize the library */
    if (!glfwInit())
        return -1;


    /* Create a windowed mode window and its OpenGL context */
    window = glfwCreateWindow(Width, Height, "CG LR5 V5.1.24", NULL, NULL);
    if (!window)
    {
        std::cout << "Failed to create GLFW window" << std::endl;
        glfwTerminate();
        return -1;
    }

    glfwSetCursorPosCallback(window, CursorPositionCallback);
    glfwSetCursorEnterCallback(window, CursorEnterCallback);
    glfwSetScrollCallback(window, ScrollCallback);
    glfwSetKeyCallback(window, KeyCallback);
    glfwSetFramebufferSizeCallback(window, FrameBufferSizeCallback);
    glfwSetMouseButtonCallback(window, MouseButtonCallback);

    /* Make the window's context current */
    glfwMakeContextCurrent(window);

    /* init glad */
    if (!gladLoadGLLoader((GLADloadproc)glfwGetProcAddress))
    {
        std::cout << "Failed to initialize GLAD" << std::endl;
        return -1;
    }

    float vertices[] = {
        // position               // texture
        -0.5f,  -0.5f,   0.0f,    0.0f, 0.0f,

         0.5f,  -0.5f,   0.0f,    1.0f, 0.0f,
         
         0.5f,   0.5f,   0.0f,    1.0f, 1.0f,
        
         -0.5f,   0.5f,   0.0f,   0.0f, 1.0f,

    };

    float xAxis[] = {
         100.f, 0.f, 0.f,
        -100.f, 0.f, 0.f
    };

    float yAxis[] = {
         0.f, -100.f, 0.f,
        -0.f,  100.f, 0.f
    };

    float zAxis[] = {
         0.f, 0.f, -100.f,
        -0.f, 0.f,  100.f
    };

    auto VBO_xAxis = new VertexBufferObject(xAxis, 2 * 3 * sizeof(float));
    auto VBO_yAxis = new VertexBufferObject(yAxis, 2 * 3 * sizeof(float));
    auto VBO_zAxis = new VertexBufferObject(zAxis, 2 * 3 * sizeof(float));

    auto VAO_xAxis = new VertexArrayObject();
    auto VAO_yAxis = new VertexArrayObject();
    auto VAO_zAxis = new VertexArrayObject();

    auto layoutAxis = new VertexBufferLayout();
    layoutAxis->Push<float>(3);

    VAO_xAxis->AddBuffer(*VBO_xAxis, *layoutAxis);
    VAO_yAxis->AddBuffer(*VBO_yAxis, *layoutAxis);
    VAO_zAxis->AddBuffer(*VBO_zAxis, *layoutAxis);


    unsigned int indices[] = {
        0,1,2,  0,2,3
    };

    auto VBO = new VertexBufferObject(vertices, 4 * 5 * sizeof(float));
    auto VAO = new VertexArrayObject();
    auto EBO = new ElementBufferObject(indices, sizeof(unsigned int), 6);
    
    auto layout = new VertexBufferLayout();
    layout->Push<float>(3);
    layout->Push<float>(2);
    VAO->AddBuffer(*VBO, *layout);

    VBO->Unbind();
    VAO->Unbind();
    EBO->Unbind();


    Texture* diffuseMap = new Texture("res/textures/brick.png");
    Texture* normalMap = new Texture("res/textures/brick_normal.png");
    Texture* depthMap = new Texture("res/textures/brick_bump.png");

    diffuseMap->Bind(0);
    normalMap->Bind(1);
    depthMap->Bind(2);

    auto renderer = new Renderer();
    auto shader = new Shader("res/shaders/surface.vert", "res/shaders/surface.frag");
    shader->SetUniform1b("UseParallaxOcclusion", true);
    
    glClearColor(0, 0, 0, 1);
    glEnable(GL_DEPTH);

    /* Loop until the user closes the window */
    while (!glfwWindowShouldClose(window))
    {
        glm::mat4 model = 
            glm::transpose(glm::translate(glm::mat4(1.f), position)) *
            rotation *
            glm::scale(glm::mat4(1.f), scale);

        //glm::mat4 proj = glm::frustum(-ScreenRatio, ScreenRatio, -1.f, 1.f, 1.f, 100.f);
        glm::mat4 proj = glm::perspective(45.f, ScreenRatio, 0.5f, 100.f);


        glm::mat4 view = glm::transpose(glm::lookAt(
            CameraPosition,
            EyeSight,
            CameraHead
        ));


        /* Render here */
        renderer->Clear();

        shader->Bind();
        shader->SetUniformMatrix4f("model", model);
        shader->SetUniformMatrix4f("view", view);
        shader->SetUniformMatrix4f("proj", proj);


        shader->SetUniform3f("normal", normal.x, normal.y, normal.z);
        shader->SetUniform3f("tangent", tangent.x, tangent.y, tangent.z);
        shader->SetUniform3f("bitangent", bitangent.x, bitangent.y, bitangent.z);
        //shader->SetUniform4f("color", color.r, color.g, color.b, color.a);

        shader->SetUniform1i("diffuseMap", 0);
        shader->SetUniform1i("normalMap", 1);
        shader->SetUniform1i("depthMap", 2);

        shader->SetUniform3f("Light", LightPosition.x, LightPosition.y, LightPosition.z);
        shader->SetUniform4f("LightColor", LightColor.r, LightColor.g, LightColor.b, LightColor.a);

        shader->SetUniform3f("eye", CameraPosition.x, CameraPosition.y, CameraPosition.z);

        shader->SetUniform1b("UseParallaxOcclusion", UseParallaxOcclusion);

        shader->SetUniform4f("color", 1, 0, 0, 1);
        renderer->Draw(GL_LINES, VAO_xAxis);
        shader->SetUniform4f("color", 0, 1, 0, 1);
        renderer->Draw(GL_LINES, VAO_yAxis);
        shader->SetUniform4f("color", 0, 0, 1, 1);
        renderer->Draw(GL_LINES, VAO_zAxis);


        shader->SetUniform4f("color", 1, 1, 1, 1);
        renderer->Draw(GL_TRIANGLES, VAO, EBO);


        /* Swap front and back buffers */
        glfwSwapBuffers(window);

        /* Poll for and process events */
        glfwPollEvents();
    }

    glfwTerminate();
    return 0;
}


static void FrameBufferSizeCallback(GLFWwindow* window, int xscale, int yscale)
{
    Width = xscale;
    Height = yscale;
    ScreenRatio = (float)Width / (float)Height;
    glViewport(0, 0, Width, Height);
}



static void CursorPositionCallback(GLFWwindow* window, double xpos, double ypos)
{
    if (b_MouseOutOfWindow) return;
    if (!b_HandleMouse) return;

    double dx = xpos - Width / 2.;
    double dy = ypos - Height / 2.;

    if (b_RotationMode)
    {
        rotation = glm::rotate(rotation, glm::radians((float)dx), glm::vec3(0.f, 1.f, 0.f));
        rotation = glm::rotate(rotation, glm::radians((float)dy), glm::vec3(1.f, 0.f, 0.f));
    }
    else
    {
        float f_SightChangeX = (float)dx * MOUSE_SENSITIVITY_X / 1000;
        float f_SightChangeY = -(float)dy * MOUSE_SENSITIVITY_Y / 1000;

        EyeSight.x += f_SightChangeX;
        if (EyeSight.x > 1) EyeSight.x = 1;
        if (EyeSight.x < -1) EyeSight.x = -1;

        EyeSight.y += f_SightChangeY;
        if (EyeSight.y > 1) EyeSight.y = 1;
        if (EyeSight.y < -1) EyeSight.y = -1;
    }

    glfwSetCursorPos(window, Width / 2.f, Height / 2.f);
}


static void MouseButtonCallback(GLFWwindow* window, int button, int action, int mods)
{
    if (button == GLFW_MOUSE_BUTTON_1)
    {
        b_RotationMode = action == GL_TRUE;
    }
}


static void ScrollCallback(GLFWwindow* window, double xoffset, double yoffset)
{
    scale += scale.x * yoffset / 5;
    if (scale.x < 1)
    {
        scale = glm::vec3(1.f, 1.f, 1.f);
    }
}


static void CursorEnterCallback(GLFWwindow* window, int entered)
{
    b_MouseOutOfWindow = entered == GLFW_FALSE;
    if (!b_MouseOutOfWindow && b_HandleMouse) 
    {
        glfwSetCursorPos(window, Width / 2.f, Height / 2.f);
        glfwSetInputMode(window, GLFW_CURSOR, GLFW_CURSOR_HIDDEN);
    }
}


static void KeyCallback(GLFWwindow* window, int key, int scancode, int action, int mods)
{
    if (key == GLFW_KEY_ESCAPE)
    {
        glfwSetWindowShouldClose(window, true);
    }

    if (key == GLFW_KEY_TAB)
    {
        b_HandleMouse = action == GLFW_FALSE;
        if (b_HandleMouse && ! b_MouseOutOfWindow) 
        {
            glfwSetInputMode(window, GLFW_CURSOR, GLFW_CURSOR_HIDDEN);
            glfwSetCursorPos(window, Width / 2.f, Height / 2.f);
        }
        else
        {
            glfwSetInputMode(window, GLFW_CURSOR, GLFW_CURSOR_NORMAL);
        }
    }

    if (key == GLFW_KEY_Q && action == GLFW_PRESS)
    {
        UseParallaxOcclusion = !UseParallaxOcclusion;
    }

    if (key == 334 && action == GLFW_PRESS)
    {
        scale *= glm::vec3(1.5f);
    }

    if (key == 333 && action == GLFW_PRESS)
    {
        scale /= glm::vec3(1.5f);
    }
}
