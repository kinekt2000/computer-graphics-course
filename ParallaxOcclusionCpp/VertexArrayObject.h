#pragma once
class VertexBufferObject;
class VertexBufferLayout;

class VertexArrayObject
{
private:
	unsigned int vao;
	unsigned int count;

public:
	VertexArrayObject();
	~VertexArrayObject();

	void AddBuffer(const VertexBufferObject& vb, const VertexBufferLayout& layout);

	void Bind() const;
	void Unbind() const;

	inline unsigned int GetCount() const { return count; }
};

