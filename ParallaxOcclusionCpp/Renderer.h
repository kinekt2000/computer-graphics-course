#pragma once

#define ASSERT(x) if(!(x)) __debugbreak();

#define GLCall(x) GLCLearError();\
	x;\
	ASSERT(GLLogCall(#x, __FILE__, __LINE__))


void GLCLearError();
bool GLLogCall(const char* function, const char* file, int line);


class VertexArrayObject;
class ElementBufferObject;
class Shader;

class Renderer
{
public:
	void Clear() const;
	void Draw(unsigned int primitive, const VertexArrayObject* vao, const ElementBufferObject* ebo = nullptr) const;
};