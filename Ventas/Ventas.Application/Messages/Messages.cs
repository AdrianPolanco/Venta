
namespace Ventas.Application.Messages
{
    public class StatusMessages
    {
        public static readonly string POST_SUCCESS = "Recurso creado correctamente.";
        public static readonly string POST_FAILURE = "Creación del recurso fallida.";
        public static readonly string POST_INVALID = "Creación del recurso fallida: No se obtuvieron todos los datos necesarios para la creación del nuevo recurso";
        public static readonly string GET_SUCCESS = "Recurso obtenido correctamente.";
        public static readonly string GET_NOTFOUND = "No se pudo encontrar el recurso.";
        public static readonly string GET_FAILURE = "No se pudo obtener los recursos.";
        public static readonly string PUT_SUCCESS = "Recurso actualizado correctamente.";
        public static readonly string PUT_FAILURE = "Actualización del recurso fallida.";
        public static readonly string PUT_INVALID = "Actualización del recurso fallida: No se obtuvieron todos los datos necesarios para la actualización del recurso o el recurso no existe";
        public static readonly string DELETE_SUCCESS = "Recurso eliminado correctamente.";
        public static readonly string DELETE_FAILURE = "Eliminación del recurso fallida.";
        public static readonly string DELETE_NOTFOUND = "Eliminación del recurso fallida: El recurso no existe.";
    }
}
