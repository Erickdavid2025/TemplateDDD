using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.DTOs.Input;
using Template.Application.Interfaces.Repository;
using Template.Application.Queries;
using Template.Domain.Entities;
using Template.Infraestructure.ORM_Context;

namespace Template.Infraestructure.Repositores
{
    public class TarjetaRepository : ITarjetaRepository
    {
        private readonly MyDbContext _myDbContext;
        public TarjetaRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<bool> ExistsTarjeta(string numeroTarjeta)
        {
            var tarjeta = await _myDbContext.Tarjetas.AnyAsync(x => x.Numero == numeroTarjeta) != null ? true:false ;
            return tarjeta;
        }

        public async Task<Tarjeta> ExistsTarjeta(int id)
        {
            return await _myDbContext.Tarjetas.Where(x => x.Id == id).FirstOrDefaultAsync();
         
        }

        public async Task<int> SaveTarjeta(Tarjeta tarjeta)
        {
            try
            {
                await _myDbContext.Tarjetas.AddAsync(tarjeta);
                await _myDbContext.SaveChangesAsync();
                return tarjeta.Id;
            }
            catch (Exception x)
            {

                throw x;
            }
     
        }
    }
}
