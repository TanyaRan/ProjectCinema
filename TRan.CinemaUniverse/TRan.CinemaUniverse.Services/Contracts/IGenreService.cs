﻿using System;
using System.Linq;
using TRan.CinemaUniverse.Models;

namespace TRan.CinemaUniverse.Services.Contracts
{
    public interface IGenreService
    {
        IQueryable<Genre> GetAll();

        IQueryable<Genre> GetAllAndDeleted();

        IQueryable<Genre> GetDeleted();

        void Add(Genre genre);

        Genre GetById(Guid id);

        void Update(Genre genre);

        void Delete(Guid id);
    }
}
