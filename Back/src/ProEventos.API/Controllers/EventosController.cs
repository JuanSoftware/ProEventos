﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        
        
        private readonly DataContext _contex;
        public EventosController(DataContext context)
        {
            _contex = context;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _contex.Eventos;
        }

        [HttpGet("{id}")]
        public Evento GetById(int id)
        {
#pragma warning disable CS8603 // Possível retorno de referência nula.
            return _contex.Eventos.FirstOrDefault(evento => evento.EventoId == id);
#pragma warning restore CS8603 // Possível retorno de referência nula.
        }

        [HttpPost]
        public string Post()
        {
            return "Exemplo de Post";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Exemplo de Put com id = {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Exemplo de Delete com id = {id}";
        }
    }
}