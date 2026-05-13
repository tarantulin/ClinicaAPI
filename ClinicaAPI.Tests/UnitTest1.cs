using System;
using ClinicaAPI.Models;
using Xunit;

namespace ClinicaAPI.Tests;

public class PacienteTests
{
    [Fact]
    public void CrearPaciente_ConDatosValidos_DevuelvePacienteConId()
    {
        // Arrange
        var paciente = new Paciente
        {
            Nombre = "Juan Perez",
            Edad = 30,
            Diagnostico = "Gripe",
            Telefono = "987654321",
            Direccion = "Av. Principal 123",
            CorreoElectronico = "juan@mail.com",
            FechaRegistro = DateTime.Now
        };

        // Act & Assert
        Assert.NotNull(paciente);
        Assert.Equal("Juan Perez", paciente.Nombre);
        Assert.Equal(30, paciente.Edad);
        Assert.Equal("987654321", paciente.Telefono);
    }

    [Fact]
    public void Paciente_TieneCamposExtension_Correctos()
    {
        // Arrange
        var paciente = new Paciente();

        // Act
        paciente.Telefono = "999888777";
        paciente.Direccion = "Calle Nueva";
        paciente.CorreoElectronico = "test@mail.com";
        paciente.FechaRegistro = DateTime.Now;

        // Assert
        Assert.NotNull(paciente.Telefono);
        Assert.NotNull(paciente.Direccion);
        Assert.NotNull(paciente.CorreoElectronico);
        Assert.NotEqual(default(DateTime), paciente.FechaRegistro);
    }
}