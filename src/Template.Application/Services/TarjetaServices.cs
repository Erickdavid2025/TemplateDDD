using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.DTOs.Input;
using Template.Application.DTOs.Output;
using Template.Application.Interfaces;
using Template.Application.Interfaces.Repository;
using Template.Domain.Entities;

namespace Template.Application.Services
{
    public class TarjetaServices : ITarjeta
    {
        private readonly ITarjetaRepository _tarjetaRepository;
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IMapper _mapper;

        public TarjetaServices(ITarjetaRepository tarjetaRepository, ICuentaRepository cuentaRepository, IMapper mapper)
        {
            _tarjetaRepository = tarjetaRepository;
            _cuentaRepository = cuentaRepository;
            _mapper = mapper;
        }
        public async Task<NuevaTarjetaOutput> AltaTarjeta(NuevaTarjetaInput nuevaTarjetaInput)
        {
            try
            {
                if (!await _cuentaRepository.ExisteCuenta(nuevaTarjetaInput.CuentaId)) throw new Exception("No existe la cuenta");
                if (!await _tarjetaRepository.ExistsTarjeta(nuevaTarjetaInput.Numero)) throw new Exception("Ya existe la tarjeta en bd");

                var dataModel = _mapper.Map<Tarjeta>(nuevaTarjetaInput);
                var idTarjeta = await _tarjetaRepository.SaveTarjeta(dataModel);

                if (idTarjeta < 0) throw new Exception("Error el crear la tarjeta");
                Tarjeta datosTarjeta;
                datosTarjeta = await _tarjetaRepository.ExistsTarjeta(idTarjeta);
                var response = _mapper.Map<NuevaTarjetaOutput>(datosTarjeta);

                return response;
            }
            catch (Exception x)
            {

                throw x;
            }

        }
    }
}
