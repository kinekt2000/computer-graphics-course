#pragma once
class VertexBufferObject
{
private:
    unsigned int buffer;
    unsigned int size;

public:
    VertexBufferObject(const void* data, unsigned int size);
    ~VertexBufferObject();

    void Bind() const;
    void Unbind() const;

    inline unsigned int GetSize() const { return size; }
};

