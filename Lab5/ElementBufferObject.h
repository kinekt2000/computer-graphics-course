#pragma once
class ElementBufferObject
{
private:
    unsigned int buffer;
    unsigned int count;
public:
    ElementBufferObject(const void* data, unsigned int size_per_index, unsigned int count);
    ~ElementBufferObject();

    void Bind() const;
    void Unbind() const;

    inline unsigned int GetCount() const { return count; }
};

