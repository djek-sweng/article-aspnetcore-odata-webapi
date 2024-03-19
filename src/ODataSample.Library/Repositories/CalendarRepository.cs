namespace ODataSample.Library.Repositories;

public class CalendarRepository : ICalendarRepository
{
    private readonly DatabaseContext _context;

    public CalendarRepository(DatabaseContext context)
    {
        _context = context;
    }

    public IQueryable<Calendar> Query => _context.Calendars.AsQueryable();

    public IReadOnlyList<Calendar> List => Query
        .Include(c => c.Meetings)
        .ThenInclude(m => m.Reminders)
        .ToList();
}
