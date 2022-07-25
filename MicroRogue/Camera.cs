using System;

namespace MicroRogue.Console
{
    class Camera
    {
        public int width;
        public int height;
        public int LeftPos;
        public int TopPos;
        public Camera(int leftSize, int topSize)
        {
            width = leftSize;
            height = topSize;
        }
    }
}
