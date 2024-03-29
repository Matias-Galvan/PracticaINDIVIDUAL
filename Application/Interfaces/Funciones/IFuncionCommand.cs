﻿using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces.Funciones
{
    public interface IFuncionCommand
    {
        void CrearFuncion(Funcion funcion);
        Task<FuncionDTOResponse> CrearFnc(Funcion funcion);
        Task<FuncionDTOResponse> ActualizarFuncion(int funcionId);
        Task<FuncionDTOResponseDetail> EliminarFuncion(int funcionId);
    }
}
