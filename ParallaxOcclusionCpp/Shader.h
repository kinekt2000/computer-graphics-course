#pragma once

#include <glm/matrix.hpp>

#include <string>
#include <unordered_map>

using glm::mat4;

class Shader
{
private:
    const std::string m_VertPath;
    const std::string m_FragPath;

    unsigned int m_RendererID;
    std::unordered_map<std::string, int> m_UniformLocationCache;

public:
    Shader() = delete;
    Shader(const std::string& vertSource, const std::string& fragSource);
    ~Shader();

    void Bind() const;
    void Unbind() const;

    // Set variables
    void SetUniform1f(const std::string& name, float v0);
    void SetUniform2f(const std::string& name, float v0, float v1);
    void SetUniform3f(const std::string& name, float v0, float v1, float v2);
    void SetUniform4f(const std::string& name, float v0, float v1, float v2, float v3);

    void SetUniform1i(const std::string& name, int v0);

    void SetUniform1b(const std::string& name, bool v0);

    void SetUniformMatrix4f(const std::string& name, const mat4& matrix);

private:
    std::string OpenFile(const std::string& filename);
    unsigned int CreateShader(const std::string& vertexShader, const std::string& fragmentShader);
    unsigned int CompileShader(const std::string& source, unsigned int type);
    
    int GetUniformLocation(const std::string& name);
};

