﻿using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using MoviesAPI.Data;
using System;

namespace MoviesAPI.Services
{
    public class MoviesService
    {
        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context)
        {
            _context = context;
        }
		public async Task<List<Movie>> GetMoviesAsync()
		{
            return await _context.Movies.ToListAsync();
        }
        public async Task<List<Movie>> GetMoviesAsync(int Id)
        {
            return await _context.Movies.ToListAsync();
        }
	
		public object AppDbcontext { get; private set; }

        public void AddMovie(Movie movie)
        {
            if (movie is null)
            {
                throw new ArgumentNullException(nameof(movie));
            }

            var newMovie = new Movie()
            {
                Title = movie.Title,
                Year = movie.Year,
                Id = movie.Id,
                Genre = movie.Genre,
                MovieAdded = movie.MovieAdded,
                MovieDeleted = movie.MovieDeleted,
            };
            _context.Movies.Add(newMovie);
            _context.SaveChanges();
        }
    }
}
