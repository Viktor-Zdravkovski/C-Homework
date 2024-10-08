﻿using BurgerShop.DataBase.Interfaces;
using BurgerShop.Domain;
using BurgerShop.Dtos;
using BurgerShop.Service.Interfaces;

namespace BurgerApp.Services
{
    public class BurgerService : IBurgerService
    {
        private readonly IRepository<Burger> _burgerRepository;

        public List<BurgerDto> ShowAllBurgers()
        {
            return _burgerRepository.GetAll().Select(b => new BurgerDto
            {
                Id = b.Id,
                Name = b.Name,
                Price = b.Price,
                IsVegetarian = b.IsVegetarian,
                IsVegan = b.IsVegan,
                HasFries = b.HasFries
            }).ToList();
        }

        public BurgerDto GetBurgerById(int id)
        {
            var burger = _burgerRepository.GetById(id);
            if (burger == null) return null;
            return new BurgerDto
            {
                Id = burger.Id,
                Name = burger.Name,
                Price = burger.Price,
                IsVegetarian = burger.IsVegetarian,
                IsVegan = burger.IsVegan,
                HasFries = burger.HasFries
            };
        }

        public void AddBurger(BurgerDto burgerDto)
        {
            var burger = new Burger
            {
                Name = burgerDto.Name,
                Price = burgerDto.Price,
                IsVegetarian = burgerDto.IsVegetarian,
                IsVegan = burgerDto.IsVegan,
                HasFries = burgerDto.HasFries
            };
            _burgerRepository.Add(burger);
        }

        public void EditBurger(BurgerDto burgerDto)
        {
            var burger = new Burger
            {
                Id = burgerDto.Id,
                Name = burgerDto.Name,
                Price = burgerDto.Price,
                IsVegetarian = burgerDto.IsVegetarian,
                IsVegan = burgerDto.IsVegan,
                HasFries = burgerDto.HasFries
            };
            _burgerRepository.Update(burger);
        }

        public void DeleteBurger(int id)
        {
            _burgerRepository.Delete(id);
        }
    }
}
