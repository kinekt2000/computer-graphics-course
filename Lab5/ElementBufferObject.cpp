#include <glad/glad.h>

#include <climits>

#include "ElementBufferObject.h"
#include "Renderer.h"
#include <iostream>

ElementBufferObject::ElementBufferObject(const void* data, unsigned int size, unsigned int count)
    :count(count)
{
    unsigned int actual_size = size * count;
    ASSERT(size == actual_size / count);

    GLCall(glGenBuffers(1, &buffer));
    GLCall(glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, buffer));
    GLCall(glBufferData(GL_ELEMENT_ARRAY_BUFFER, actual_size, data, GL_STATIC_DRAW));
}

ElementBufferObject::~ElementBufferObject()
{
    glDeleteBuffers(1, &buffer);
}

void ElementBufferObject::Bind() const
{
    glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, buffer);
}

void ElementBufferObject::Unbind() const
{
    glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, 0);
}
