#pragma once
#include "glad/glad.h"

#include <vector>
#include "Renderer.h"

struct VertexBufferElement
{
    unsigned int type;
    int count;
    unsigned char normalized;

    static int GetSizeOfType(unsigned int type)
    {
        switch (type) {
        case GL_FLOAT:			return 4;
        case GL_UNSIGNED_INT:	return 4;
        case GL_UNSIGNED_BYTE:	return 1;
        case GL_INT:			return 4;
        case GL_BYTE:			return 1;
        }

        ASSERT(false);
        return 0;
    }
};

class VertexBufferLayout
{
private:
    std::vector<VertexBufferElement> elements;
    int stride = 0;

public:
    VertexBufferLayout()
        :stride(0) {};

    template<typename T>
    void Push(int count)
    {
        static_assert(false);
    }

    template<>
    void Push<float>(int count)
    {
        elements.push_back({ GL_FLOAT, count, GL_FALSE });
        stride += count * VertexBufferElement::GetSizeOfType(GL_FLOAT);
    }


    template<>
    void Push<unsigned int>(int count)
    {
        elements.push_back({ GL_UNSIGNED_INT, count, GL_FALSE });
        stride += count * VertexBufferElement::GetSizeOfType(GL_UNSIGNED_INT);
    }


    template<>
    void Push<unsigned char>(int count)
    {
        elements.push_back({ GL_UNSIGNED_BYTE, count, GL_TRUE });
        stride += count * VertexBufferElement::GetSizeOfType(GL_UNSIGNED_BYTE);
    }

    template<>
    void Push<int>(int count)
    {
        elements.push_back({ GL_INT, count, GL_FALSE });
        stride += count * VertexBufferElement::GetSizeOfType(GL_INT);
    }

    template<>
    void Push<char>(int count)
    {
        elements.push_back({ GL_BYTE, count, GL_TRUE });
        stride += count * VertexBufferElement::GetSizeOfType(GL_BYTE);
    }


    inline const std::vector<VertexBufferElement> GetElements() const { return elements; }
    inline const int GetStride() const { return stride; }
};

