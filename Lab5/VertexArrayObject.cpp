#include "VertexArrayObject.h"
#include "VertexBufferObject.h"
#include "VertexBufferLayout.h"
#include "Renderer.h"
#include <iostream>


VertexArrayObject::VertexArrayObject()
    : count(0)
{
    GLCall(glGenVertexArrays(1, &vao));
}

VertexArrayObject::~VertexArrayObject()
{
    GLCall(glDeleteVertexArrays(1, &vao));
}

void VertexArrayObject::AddBuffer(const VertexBufferObject& vb, const VertexBufferLayout& layout)
{
    Bind();
    vb.Bind();
    const auto& elements = layout.GetElements();
    unsigned int offset = 0;
    for (unsigned int i = 0; i < elements.size(); i++)
    {
        const auto& element = elements[i];

        GLCall(glEnableVertexAttribArray(i));
        GLCall(glVertexAttribPointer(i, element.count, element.type, element.normalized, layout.GetStride(), (const void*)offset));
        offset += element.count * VertexBufferElement::GetSizeOfType(element.type);
    }


    count = vb.GetSize() / offset;
}

void VertexArrayObject::Bind() const
{
    GLCall(glBindVertexArray(vao));
}

void VertexArrayObject::Unbind() const
{
    GLCall(glBindVertexArray(0));
}
