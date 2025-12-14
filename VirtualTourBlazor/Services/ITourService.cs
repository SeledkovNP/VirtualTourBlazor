using VirtualTourBlazor.Models;

namespace VirtualTourBlazor.Services
{
    public interface ITourService
    {
        List<Tour> GetAllTours();
        Tour? GetTourById(int id);
        void AddTour(Tour tour);
        void UpdateTour(Tour tour);
        void DeleteTour(int id);
        void AddReview(int tourId, Review review);
        List<Guide> GetAllGuides();
    }
}