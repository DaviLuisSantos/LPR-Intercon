using System;
using System.Collections.Generic;
using System.Text;

namespace AppSharedProject.Models;

public class ControlIdUsuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Matricula { get; set; }
    public byte[] Foto { get; set; }
    public int Grupo { get; set; } = 1;
    public bool Arquivamento { get; set; }
    public DateTime ValidadeInicio { get; set; } = DateTime.MinValue;
    public DateTime ValidadeFim { get; set; } = DateTime.MaxValue;
}
