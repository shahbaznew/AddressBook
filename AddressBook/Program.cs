using AddressBook.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IContactService>(provider =>
{
    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "contacts.json");
    return new ContactService(filePath);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
