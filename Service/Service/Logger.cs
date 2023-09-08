using System;
using System.ComponentModel;
using System.IO;
using System.ServiceProcess;
using System.Timers;

class ServiceLogger
{
   
    public static void GrabarLog(string sistema, string titulo, string texto)
    {
        string logPath = "C:\\Users\\nicof\\OneDrive\\Escritorio\\6to\\Windows\\Service\\Log";
        // Verificar si la carpeta de registro existe, y si no, crearla
        if (!Directory.Exists(logPath))
        {
            Directory.CreateDirectory(logPath);
        }

        // Obtener la fecha y hora actual
        DateTime now = DateTime.Now;

        // Formatear la línea de registro con fecha, hora, sistema, título y texto
        string logLine = $"{now:yyyy-MM-dd HH:mm:ss} - {sistema} - {titulo} - {texto}";
        string logFile = "logs.log";
        // Ruta completa del archivo de registro
        string logFilePath = Path.Combine(logPath, logFile);
        try
        {
            // Escribir la línea de registro en el archivo
            File.AppendAllText(logFilePath, logLine + Environment.NewLine);
        }
        catch (Exception ex)
        {
            // Si hay un error al escribir en el archivo de registro, registrar el error
            Console.WriteLine($"Error al escribir en el archivo de registro: {ex.Message}");
        }
    }

}
