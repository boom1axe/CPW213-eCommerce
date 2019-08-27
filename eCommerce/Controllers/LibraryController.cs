﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Data;
using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class LibraryController : Controller
    {
        private readonly GameContext _context;

        public LibraryController(GameContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Search(SearchCriteria criteria)
        {
            if (validSearch(criteria))
            {
                criteria.GameResults = await VideoGameDb.SearchAsync(_context, criteria);
            }
            

            return View(criteria);
        }

        /// <summary>
        /// returns true if user searched by at least
        /// one criteria
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        private bool validSearch(SearchCriteria criteria)
        {
            if (criteria.Title == null &&
                criteria.Rating == null &&
                criteria.MinPrice == null &&
                criteria.MaxPrice == null)
            {
                return false;
            }

            return true;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<VideoGame> allGames =
                await VideoGameDb.GetAllGames(_context);
            return View(allGames);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(VideoGame game)
        {
            if (ModelState.IsValid)
            {
                // Add to database
                await VideoGameDb.AddAsync(game, _context);
                return RedirectToAction("index");
            }

            // Return View with model including error messages
            return View(game);
        }

        public async Task<IActionResult> Update(int id)
        {
            VideoGame game =
                await VideoGameDb.GetGameById(id, _context);
            return View(game);
        }

        [HttpPost]
        public async Task<IActionResult> Update(VideoGame g)
        {
            if (ModelState.IsValid)
            {
                await VideoGameDb.UpdateGame(g, _context);
                return RedirectToAction("Index");
            }

            // If there are any errors, show the user
            // the form again
            return View(g);
        }
    }
}