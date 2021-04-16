#include "Renderer.h"

#include <glad/glad.h>
#include <iostream>

#include "VertexArrayObject.h"
#include "ElementBufferObject.h"
#include "Shader.h"


void GLCLearError()
{
	while (glGetError() != GL_NO_ERROR);
}


bool GLLogCall(const char* function, const char* file, int line)
{
	while (GLenum error = glGetError())
	{
		std::cout << "[OpenGL error] (" << std::hex << error << "): " << function <<
			" " << file << ": " << std::dec << line << std::endl;
		return false;
	}

	return true;
}


void Renderer::Clear() const
{
	GLCall(glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT));
}

void Renderer::Draw(unsigned int primitive, const VertexArrayObject* vao, const ElementBufferObject* ebo) const
{
	if (vao == nullptr) return;
	
	vao->Bind();

	if (ebo)
	{
		ebo->Bind();
		GLCall(glDrawElements(primitive, ebo->GetCount(), GL_UNSIGNED_INT, nullptr));
	}
	else
	{
		GLCall(glDrawArrays(primitive, 0, vao->GetCount()));
	}
}