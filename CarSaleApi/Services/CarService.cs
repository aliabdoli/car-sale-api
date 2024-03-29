﻿using System.Collections.Generic;
using System.Threading.Tasks;
using CarSaleApi.Models;
using CarSaleApi.Repositories;
using Microsoft.Extensions.Logging;

namespace CarSaleApi.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly ILogger<CarService> _logger;

        public CarService(ICarRepository carRepository, ILogger<CarService> logger)
        {
            _carRepository = carRepository;
            _logger = logger;
        }

        public async Task<int> AddAsync(Car car)
        {
            _logger.LogInformation("adding a car");
            var newCar = await _carRepository.AddAsync(car);
            return newCar.Id;
        }

        public async Task UpdateAsync(Car car)
        {
            _logger.LogInformation($"updating the car. car id: {car.Id}");
            await _carRepository.UpdateAsync(car);
        }

        public async Task<Car> GetCarAsync(int id)
        {
            _logger.LogInformation($"getting a car. car id: {id}");
            return await _carRepository.GetCarAsync(id);
        }

        public async Task<List<Car>> GetCarsAsync(List<int> ids)
        {
            _logger.LogInformation($"getting list of cars. car ids: {string.Join(",", ids)}");
            return await _carRepository.GetCarsAsync(ids);
        }
    }
}