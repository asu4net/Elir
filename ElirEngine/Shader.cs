using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ElirEngine
{
    public class Shader : IDisposable
    {
        /*
         Representa la localización final de 
         nuestro shader después de ser compilado.
         */
        int shaderLocation;
        bool disposeableValue;

        const string SHADER_FOLDER = "Shaders";
        const string VERTEX_PATH = "shader.vert";
        const string FRAGMENT_PATH = "shader.frag";

        public Shader(string vertexPath = VERTEX_PATH,
            string fragmentPath = FRAGMENT_PATH)
        {
            var vertex = CreateShader(ShaderType.VertexShader, vertexPath);
            var fragment = CreateShader(ShaderType.FragmentShader, fragmentPath);

            if (!CompileShader(vertex, vertexPath) || 
                !CompileShader(fragment, fragmentPath))
                return;

            CreateHandle(vertex, fragment);
        }

        public void Use()
            => GL.UseProgram(shaderLocation);

        public int GetAttribLocation(string attribName)
            => GL.GetAttribLocation(shaderLocation, attribName);

        public void SetUniformVec4(string attribName, Vector4 value)
        {
            int location = GL.GetUniformLocation(shaderLocation, attribName);
            GL.Uniform4(location, value.X, value.Y, value.Z, value.W);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~Shader()
            => GL.DeleteProgram(shaderLocation);

        void Dispose(bool disposing)
        {
            if (disposeableValue) return;
            GL.DeleteProgram(shaderLocation);
            disposeableValue = true;
        }

        string GetSourceCode(string path)
        {
            string sourceCode;

            using (StreamReader reader = new StreamReader(path))
            {
                sourceCode = reader.ReadToEnd();
            }

            return sourceCode;
        }

        int CreateShader(ShaderType type, string path)
        {
            Log.Debug($"Creando {path}...");
            var completePath = $"{Utils.GetProjectDir()}{@"\"}{SHADER_FOLDER}{@"\"}{path}";
            int shader = GL.CreateShader(type);
            GL.ShaderSource(shader, GetSourceCode(completePath));
            Log.Debug($"{path} creado.");
            return shader;
        }

        bool CompileShader(int shader, string path)
        {
            Log.Debug($"Compilando {path}...");
            GL.CompileShader(shader);
            var shaderError = GL.GetShaderInfoLog(shader);
            if (shaderError != string.Empty)
            {
                Log.Error($"Error de compilado en {path} : {shaderError}");
                return false;
            }
            Log.Debug($"{path} compilado.");
            return true;
        }

        void CreateHandle(int vertex, int fragment)
        {
            Log.Debug($"Combinando shaders...");
            shaderLocation = GL.CreateProgram();

            GL.AttachShader(shaderLocation, vertex);
            GL.AttachShader(shaderLocation, fragment);

            GL.LinkProgram(shaderLocation);

            GL.DetachShader(shaderLocation, vertex);
            GL.DetachShader(shaderLocation, fragment);

            GL.DeleteShader(vertex);
            GL.DeleteShader(fragment);
            Log.Debug($"Shaders combinados.");
        }
    }
}
