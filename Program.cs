using Raylib_cs;
using System.Numerics;

namespace HelloWorld
{
    static class Program
    {
        public static void Main()
        {
            const int screenWidth = 800;
            const int screenHeight = 450;

            Raylib.InitWindow(screenWidth, screenHeight, "Rey_Tracing_Presentation");

            Camera3D camera = new Camera3D();
            camera.position = new Vector3 (0, 10, 10);                  // Camera position
            camera.target = new Vector3 (0, 0, 0);                      // Camera looking at point
            camera.up = new Vector3 (0, 1, 0);                          // Camera up vector (rotation towards target)
            camera.fovy = 45;                                           // Camera field-of-view Y
            camera.projection = CameraProjection.CAMERA_PERSPECTIVE;    // Camera mode type

            Vector3 cubePosition = new Vector3 (0, 0, 0);

            Raylib.DisableCursor();

            Raylib.SetTargetFPS(60);        // Set our game to run at 60 frames-per-second

            while (!Raylib.WindowShouldClose()) // Detect window close button or ESC key
            {
                Raylib.UpdateCamera(ref camera, CameraMode.CAMERA_FREE);
                if (Raylib.IsKeyDown((KeyboardKey)'Z')) camera.target = new Vector3 (0, 0, 0);

                Raylib.BeginDrawing();
                    Raylib.ClearBackground(Color.WHITE);

                    Raylib.BeginMode3D(camera);
                        Raylib.DrawCube(cubePosition, 2, 2, 2, Color.RED);
                        Raylib.DrawCubeWires(cubePosition, 2, 2, 2, Color.MAROON);

                        Raylib.DrawGrid(10, 1);
                    Raylib.EndMode3D();

                    Raylib.DrawText("RayTracing!!!", 10, 40, 20, Color.BLACK);
                    Raylib.DrawFPS(10, 10);
                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}