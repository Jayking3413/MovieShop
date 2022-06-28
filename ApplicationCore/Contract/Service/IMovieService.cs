﻿using ApplicationCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contract.Service
{
    public interface IMovieService
    {
        Task<List<MovieCardModel>> GetTopGrossingMovies();
        Task<MovieDetailsModel> GetMovieDetails(int id);
        Task<List<MovieCardModel>> GetTopRatedMovies();
        Task<PagedResultSetModel<MovieCardModel>> GetMoviesByGenre(int genreId, int pageSize = 30, int pageNumber =1);
    }
}
