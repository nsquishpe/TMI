using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoRest_vPrueba.Data
{
    public class DataUsuario
    {
        //Instancia de la BD 
        Models.TecniMecanica_vPruebaEntities2 Contexto;
        //Constructor
        public DataUsuario()
        {
            Contexto = new Models.TecniMecanica_vPruebaEntities2();
            //Framework acorde a nuestros cambios IMPORTANTE
            Contexto.Configuration.ProxyCreationEnabled = false;
        }
        //METODOS PRIVADO
        //Validar cedula
        #region validar cedula
        private string ValidarCedula(string cedula)
        {
            string result = "";

            //Preguntamos si la cedula consta de 10 digitos
            if (cedula == null)
            {
                result = "incorrecta";
            }
            if (cedula.Length == 10)
            {

                //Obtenemos el digito de la region que sonlos dos primeros digitos
                int digito_region = int.Parse(cedula.Substring(0, 2));

                //Pregunto si la region existe ecuador se divide en 24 regiones
                if (digito_region >= 1 && digito_region <= 24)
                {

                    // Extraigo el ultimo digito
                    string ultimo_digito = cedula.Substring(9);

                    //Agrupo todos los pares y los sumo
                    int par1 = 0, par2 = 0, par3 = 0, par4 = 0;
                    int impar1 = 0, impar2 = 0, impar3 = 0, impar4 = 0, impar5 = 0;


                    par1 = int.Parse(cedula.Substring(1, 1));
                    par2 = int.Parse(cedula.Substring(3, 1));
                    par3 = int.Parse(cedula.Substring(5, 1));
                    par4 = int.Parse(cedula.Substring(7, 1));

                    int pares = par1 + par2 + par3 + par4;

                    //Agrupo los impares, los multiplico por un factor de 2, si la resultante es > que 9 le restamos el 9 a la resultante
                    impar1 = int.Parse(cedula.Substring(0, 1)) * 2;
                    if (impar1 > 9) { impar1 = (impar1 - 9); }

                    impar2 = int.Parse(cedula.Substring(2, 1)) * 2;
                    if (impar2 > 9) { impar2 = (impar2 - 9); }

                    impar3 = int.Parse(cedula.Substring(4, 1)) * 2;
                    if (impar3 > 9) { impar3 = (impar3 - 9); }

                    impar4 = int.Parse(cedula.Substring(6, 1)) * 2;
                    if (impar4 > 9) { impar4 = (impar4 - 9); }

                    impar5 = int.Parse(cedula.Substring(8, 1)) * 2;
                    if (impar5 > 9) { impar5 = (impar5 - 9); }

                    int impares = impar1 + impar2 + impar3 + impar4 + impar5;

                    //Suma total
                    int suma_total = (pares + impares);

                    //extraemos el primero digito
                    string primer_digito_suma = (suma_total).ToString().Substring(0, 1);

                    //Obtenemos la decena inmediata
                    int decena = (int.Parse(primer_digito_suma) + 1) * 10;

                    //Obtenemos la resta de la decena inmediata - la suma_total esto nos da el digito validador
                    int digito_validador = decena - suma_total;

                    //Si el digito validador es = a 10 toma el valor de 0
                    if (digito_validador == 10)
                        digito_validador = 0;

                    //Validamos que el digito validador sea igual al de la cedula
                    if (digito_validador == int.Parse(ultimo_digito))
                    {
                        result = ("correcto");
                    }
                    else
                    {
                        result = ("incorrecta");
                    }

                }
                else
                {
                    // imprimimos en consola si la region no pertenece
                    result = ("cédula no pertenece a ninguna region");
                }
            }
            else if (cedula.Length > 10)
            {
                //imprimimos en consola si la cedula tiene mas o menos de 10 digitos
                result = ("cédula tiene más de 10 dígitos");
            }
            else
            {
                //imprimimos en consola si la cedula tiene mas o menos de 10 digitos
                result = ("cédula tiene menos de 10 dígitos");
            }
            return result;
        }
        #endregion
        //consultar existencia de nombre de usuario y cedula
        private bool ValidaExistenciaSesionUsu(string des)
        {
            List<Models.USUARIO> des_usu = new List<Models.USUARIO>();
            des_usu = Contexto.USUARIO.Where(s => s.SESIONUSU.ToLower().Trim() == des.ToLower().Trim()).ToList();
            if (des_usu.Count() == 1) //existe la nombre de usuario 
                return true;
            return false;
        }
        private bool ValidaExisCedula(string des)
        {
            List<Models.USUARIO> cedls_usu = new List<Models.USUARIO>();
            cedls_usu = Contexto.USUARIO.Where(c => c.CEDULUSU.Trim() == des.Trim()).ToList();
            if (cedls_usu.Count() == 1) //existe cedula 
                return true;
            return false;
        }
        //Consultar integridad BD, claves foraneas
        private bool IdUsu_Auto(int ID)
        {
            List<Models.AUTOMOVIL> aut_usu = new List<Models.AUTOMOVIL>();
            aut_usu = Contexto.AUTOMOVIL.Where(a => a.IDUSU == ID).ToList();
            if (aut_usu.Count() != 0)
                return true; //existen autos con dicho usuario registrado
            return false;
        }
        private bool IdUsu_Encab(int ID)
        {
            List<Models.ORDENTRABAJOENCAB> or_usu = new List<Models.ORDENTRABAJOENCAB>();
            or_usu = Contexto.ORDENTRABAJOENCAB.Where(o => o.IDUSU == ID).ToList();
            if (or_usu.Count() != 0)
                return true; //existen cabeceras con dicho usuario
            return false;
        }
        //METODOS
        //consultar todas los usuarios
        public List<Models.USUARIO> SeleccionarUsuarios()
        {
            return Contexto.USUARIO.ToList();
        }
        //consultar usuario por ID
        public Models.USUARIO UsuarioporID(int ID)
        {
            return Contexto.USUARIO.Where(us => us.IDUSU == ID).SingleOrDefault();
        }
        //insertar usuario
        public string InsertarUsuario(Models.USUARIO us)
        {
            if(ValidarCedula(us.CEDULUSU)== "correcto")
            {
                if ((ValidaExisCedula(us.CEDULUSU) == false) && (ValidaExistenciaSesionUsu(us.SESIONUSU) == false))
                {
                    Contexto.USUARIO.Add(us);
                    Contexto.SaveChanges();
                    return "Correcto";
                }
                if (ValidaExisCedula(us.CEDULUSU) == true)
                    return "Cedula existe";
                if (ValidaExistenciaSesionUsu(us.SESIONUSU) == true)
                    return "Usuario existe";
            }
            else
                return (ValidarCedula(us.CEDULUSU));
            return "Incorrecto";
        }
        //editar usuario
        public string ActualizarUsuario(Models.USUARIO us)
        {
            Models.USUARIO ustemporal = UsuarioporID(us.IDUSU);
            if (UsuarioporID(us.IDUSU) != null)
            {
                //Edita cedula 
                if (ustemporal.CEDULUSU != us.CEDULUSU)
                {
                    if(ValidarCedula(us.CEDULUSU) == "correcto")
                    {
                        if (ValidaExisCedula(us.CEDULUSU) == true) //existe
                            return "Cedula existe";
                    } 
                    else
                        return (ValidarCedula(us.CEDULUSU));
                }
                //Edita usuario
                if (ustemporal.SESIONUSU != us.SESIONUSU)
                {
                    if (ValidaExistenciaSesionUsu(us.SESIONUSU) == true) //existe
                        return "Usuario existe";
                }
                ustemporal.IDROL = us.IDROL;
                ustemporal.NOMBREUSU = us.NOMBREUSU;
                ustemporal.EMAILUSU = us.EMAILUSU;
                ustemporal.CELUSU = us.CELUSU;
                ustemporal.DIRECCIONUSU = us.DIRECCIONUSU;
                ustemporal.SESIONUSU = us.SESIONUSU;
                ustemporal.CLAVEUSU = us.CLAVEUSU;
                ustemporal.CEDULUSU = us.CEDULUSU;
                Contexto.SaveChanges();
                return "Correcto";
            }
            return "Incorrecto";
        }
        //eliminar usuario
        public bool EliminarUsuario(int ID)
        {
            Models.USUARIO ustemporal = UsuarioporID(ID);
            if (UsuarioporID(ID) != null)
            {
                //Valido integridad claves foraneas
                if (IdUsu_Auto(ID) == true || IdUsu_Encab(ID) == true)
                    return false; //No puedo eliminar usuarios heredados a otras entidades
                Contexto.USUARIO.Remove(ustemporal);
                Contexto.SaveChanges();
                return true;
            }
            return false;
        }
    }
}