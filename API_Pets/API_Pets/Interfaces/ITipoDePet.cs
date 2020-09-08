﻿using API_Pets.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pets.Interfaces
{
    interface ITipoDePet
    {
        TipoDePet Cadastrar(TipoDePet a);
        List<TipoDePet> LerTodos();

        TipoDePet BuscarPorId(int id);
        TipoDePet Alterar(int id, TipoDePet a);
        void Excluir(int id);
    }
}
