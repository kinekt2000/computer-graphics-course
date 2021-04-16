#include "Shader.h"

#include "glad/glad.h"

#include <fstream>
#include <sstream>
#include <iostream>

struct ShaderProgramSource
{
    std::string VertexSource;
    std::string FragmentSource;
};


Shader::Shader(const std::string& vertSource, const std::string& fragSource)
    :m_VertPath(vertSource), m_FragPath(fragSource), m_RendererID(0)
{
    std::string vs = OpenFile(vertSource);
    std::string fs = OpenFile(fragSource);

    m_RendererID = CreateShader(vs, fs);
}

Shader::~Shader()
{
    if(m_RendererID) glDeleteProgram(m_RendererID);
}


std::string Shader::OpenFile(const std::string& filepath)
{
    std::ifstream stream(filepath);

    std::string content;
    content.assign(
        std::istreambuf_iterator<char>(stream),
        std::istreambuf_iterator<char>()
    );

    return content;
}

unsigned int Shader::CreateShader(const std::string& vertexShader, const std::string& fragmentShader)
{
    unsigned int program = glCreateProgram();
    unsigned int vs = CompileShader(vertexShader, GL_VERTEX_SHADER);
    unsigned int fs = CompileShader(fragmentShader, GL_FRAGMENT_SHADER);

    glAttachShader(program, vs);
    glAttachShader(program, fs);
    glLinkProgram(program);
    glValidateProgram(program);

    glDeleteShader(vs);
    glDeleteShader(fs);

    return program;
}

unsigned int Shader::CompileShader(const std::string& source, unsigned int type)
{
    unsigned int id = glCreateShader(type);
    const char* src = source.c_str();

    glShaderSource(id, 1, &src, nullptr);
    glCompileShader(id);

    int result;
    glGetShaderiv(id, GL_COMPILE_STATUS, &result);

    if (result == GL_FALSE)
    {
        int length;
        glGetShaderiv(id, GL_INFO_LOG_LENGTH, &length);
        char* message = (char*) _malloca(length * sizeof(char));
        glGetShaderInfoLog(id, length, &length, message);
        std::cout << message << std::endl;
        _freea(message);
    }

    return id;
}

void Shader::Bind() const
{
    glUseProgram(m_RendererID);
}

void Shader::Unbind() const
{
    glUseProgram(0);
}

void Shader::SetUniform1f(const std::string& name, float v0)
{
    glUniform1f(GetUniformLocation(name), v0);
}

void Shader::SetUniform2f(const std::string& name, float v0, float v1)
{
    glUniform2f(GetUniformLocation(name), v0, v1);
}

void Shader::SetUniform3f(const std::string& name, float v0, float v1, float v2)
{
    glUniform3f(GetUniformLocation(name), v0, v1, v2);
}


void Shader::SetUniform4f(const std::string& name, float v0, float v1, float v2, float v3)
{
    glUniform4f(GetUniformLocation(name), v0, v1, v2, v3);
}

void Shader::SetUniform1i(const std::string& name, int v0)
{
    glUniform1i(GetUniformLocation(name), v0);
}

void Shader::SetUniform1b(const std::string& name, bool v0)
{
    glUniform1i(GetUniformLocation(name), v0 ? 1 : 0);
}

void Shader::SetUniformMatrix4f(const std::string& name, const mat4& matrix)
{
    glUniformMatrix4fv(GetUniformLocation(name), 1, GL_TRUE, &matrix[0][0]);
}

int Shader::GetUniformLocation(const std::string& name)
{
    if (m_UniformLocationCache.find(name) != m_UniformLocationCache.end())
    {
        return m_UniformLocationCache[name];
    }

    int location = glGetUniformLocation(m_RendererID, name.c_str());
    if (location == -1)
    {
        std::cout << "Warning: uniform '" << name << "' doesn't exist!" << std::endl;
    }
    m_UniformLocationCache[name] = location;
    return location;
}
