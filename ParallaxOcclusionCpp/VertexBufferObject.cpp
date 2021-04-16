#include <glad/glad.h>
#include "VertexBufferObject.h"

#include "Renderer.h"

VertexBufferObject::VertexBufferObject(const void* data, unsigned int size)
    :size(size)
{
    GLCall(glGenBuffers(1, &buffer));
    GLCall(glBindBuffer(GL_ARRAY_BUFFER, buffer));
    GLCall(glBufferData(GL_ARRAY_BUFFER, size, data, GL_STATIC_DRAW));
}

VertexBufferObject::~VertexBufferObject()
{
    GLCall(glDeleteBuffers(1, &buffer));
}

void VertexBufferObject::Bind() const
{
    GLCall(glBindBuffer(GL_ARRAY_BUFFER, buffer));
}

void VertexBufferObject::Unbind() const
{
    GLCall(glBindBuffer(GL_ARRAY_BUFFER, 0));
}
