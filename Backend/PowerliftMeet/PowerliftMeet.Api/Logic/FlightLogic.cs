using Microsoft.EntityFrameworkCore;
using PowerliftMeet.Database;
using PowerliftMeet.Api.DTOs;
using PowerliftMeet.Api.Extensions;
using PowerliftMeet.Database.Entities;

namespace PowerliftMeet.Api.Logic;

public class FlightLogic : IFlightLogic
{
    private readonly AppDbContext _dbContext;

    public FlightLogic(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<IEnumerable<FlightDto>> GetFlightsByMeetIdAsync(Guid meetId)
    {
        return await _dbContext.Flights
            .Where(f => f.MeetId == meetId)
            .Include(f => f.Meet)
            .Include(f => f.MeetAthletes)
                .ThenInclude(ma => ma.Athlete)
                    .ThenInclude(a => a.Club)
                
            .Include(f => f.MeetAthletes)
                .ThenInclude(ma => ma.WeightClass)

            

            .Select(f => f.ToDto())
            .ToListAsync();
    }

    public async Task<FlightDto> AddFlightToMeetAsync(Guid meetId, CreateFlightRequestDto request)
    {
        var meet = await _dbContext.Meets.FindAsync(meetId);
        if (meet == null)
        {
            throw new ArgumentException($"Meet with ID {meetId} not found.");
        }

        var flight = new Flight
        {
            MeetId = meetId,
            FlightNumber = request.FlightNumber,
            Label = request.Label
        };

        // Add the flight to the database
        _dbContext.Flights.Add(flight);
        await _dbContext.SaveChangesAsync();

        // Add the specified MeetAthletes to the flight
        foreach (var meetAthleteId in request.MeetAthleteIds)
        {
            var meetAthlete = await _dbContext.MeetAthletes.FindAsync(meetAthleteId);
            if (meetAthlete != null)
            {
                flight.MeetAthletes.Add(meetAthlete);
            }
            else
            {
                throw new ArgumentException($"MeetAthlete with ID {meetAthleteId} not found.");
            }
        }

        await _dbContext.SaveChangesAsync();

        var createdFlight = await _dbContext.Flights
            .Where(f => f.Id == flight.Id)
            .Include(f => f.Meet)
            .Include(f => f.MeetAthletes)
                .ThenInclude(ma => ma.Athlete)
                    .ThenInclude(a => a.Club)
                
            .Include(f => f.MeetAthletes)
                .ThenInclude(ma => ma.WeightClass)
            .FirstOrDefaultAsync();

        if (createdFlight == null)
        {
            throw new ArgumentException($"Flight with ID {flight.Id} not found.");
        }

        return createdFlight.ToDto();
    }

    public async Task DeleteFlightAsync(Guid flightId)
    {
        var flight = await _dbContext.Flights
            .Include(f => f.MeetAthletes)
            .FirstOrDefaultAsync(f => f.Id == flightId);
        if (flight == null)
        {
            throw new ArgumentException($"Flight with ID {flightId} not found.");
        }

        foreach (var meetAthlete in flight.MeetAthletes)
        {
            meetAthlete.FlightId = null;
        }

        _dbContext.Flights.Remove(flight);
        await _dbContext.SaveChangesAsync();
    }
}
