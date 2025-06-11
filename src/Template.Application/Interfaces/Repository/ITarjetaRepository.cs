using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.DTOs.Input;
using Template.Application.Queries;
using Template.Domain.Entities;

namespace Template.Application.Interfaces.Repository
{
    public interface ITarjetaRepository
    {
        Task<int> SaveTarjeta(Tarjeta tarjeta);
        Task<bool> ExistsTarjeta(string numeroTarjeta);

        Task<Tarjeta> ExistsTarjeta(int id);
    }
}
