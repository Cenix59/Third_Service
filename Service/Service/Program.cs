using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;

namespace IncrementService
{
    class Program
    {
        static void Main(String[] args)
        {
            IncrementService service = new IncrementService();

            try
            {
                ServiceBase.Run(service);
                ServiceLogger.GrabarLog("Log", "Inicio del Servicio,", "Servicio Iniciado");
            }
            catch (Exception e) {
                ServiceLogger.GrabarLog("Log", "Service_Error al crear servicio", e.Message);
            }
        }

        

    }
}
