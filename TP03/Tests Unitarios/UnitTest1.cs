using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using EntidadesAbstractas;


namespace Tests_Unitarios
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Valida el metodo Guardar, que pueda guardar el archivo, en caso contrario
        /// deberia ingresar en la exception
        /// </summary>
        [TestMethod]
        public void ValidaGuardar()
        {
            Universidad univ = new Universidad();
            try
            {
                if (Universidad.Guardar(univ))
                    Assert.Fail("Se pudo guardar el archivo");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(Excepciones.ArchivosException));
            }
        }


        /// <summary>
        /// Valido que el DNI ingresado como string sea un numero correcto y no cualquier caracter
        /// </summary>
        [TestMethod]
        public void ValidarDni()
        {
            int aux;
            int dni = 37989031;
            Profesor prof = new Profesor(1, "nicolas", "lista", "37989031", Persona.ENacionalidad.Argentino);                     
            aux=prof.DNI;
            Assert.AreEqual(dni, aux);
        }

        /// <summary>
        /// Verifico que en el constructor de Profesor se agreguen dos clases a la 
        /// Queue<Universidad.EClases>
        /// </summary>
        [TestMethod]
        public void ValidaAgregarProfesor()
        {
           Profesor prof = new Profesor(1, "nicolas", "lista", "37989031", Persona.ENacionalidad.Argentino);
           Assert.AreEqual(prof.Clases.Count, 2);
        }

        /// <summary>
        /// Verifico que se pueda leer una universidad
        /// 
        /// </summary>
        [TestMethod]
        public void ValidaLeer()
        {
            Universidad univ = new Universidad();
            try
            {               
                if (!Universidad.Leer(out univ))
                    Assert.Fail("No se puedo guardar el archivo");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(Excepciones.ArchivosException));
            }
        }
    }
}
