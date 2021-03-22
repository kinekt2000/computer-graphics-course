#pragma once
#include <string>
class Texture
{
private:
    unsigned int tex;
    std::string filepath;
    unsigned char* localBuffer;
    int width, height, BPP;

public:
    Texture(const std::string& path);
    ~Texture();

    void Bind(unsigned int slot = 0) const;
    void Unbind() const;

    inline int GetWidth() const { return width; }
    inline int GetHeight() const { return height; }
};

