using System.Text;
using Microsoft.EntityFrameworkCore;
using Playground.API.Core.Application.DTOs;
using Playground.API.Core.Application.Interfaces;
using Playground.API.Core.Application.Models;
using Playground.API.Core.Infrastructure.SqlDatabase;
using File = Playground.API.Core.Application.Models.File;

namespace Playground.API.Core.Application.Services;

public class DataRoomService(ILlmFacade llmFacade, AppDbContext dbContext) : IDataRoomService
{
    public async Task<Guid> CreateDataRoomAsync(CreateDataRoomRequest request, CancellationToken cancellationToken)
    {
        var dataroom = new DataRoom
        {
            Id = Guid.NewGuid(),
            Name = request.Name
        };
        await dbContext.DataRooms.AddAsync(dataroom, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return dataroom.Id;
    }

    public async Task<Guid> CreateFolderAsync(Guid dataRoomId, CreateFolderRequest request, CancellationToken cancellationToken)
    {
        var dataroom = await dbContext.DataRooms.FirstOrDefaultAsync(d => d.Id == dataRoomId, cancellationToken);
        if (dataroom == default)
        {
            // TODO: Create not found exception
            throw new Exception();
        }

        var folder = new Folder
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            DataRoomId = dataRoomId,
            ParentFolderId = request.ParentFolderId
        };
        dbContext.Folders.Add(folder);
        await dbContext.SaveChangesAsync(cancellationToken);

        return folder.Id;
    }
    
    public async Task<Guid> CreateFileAsync(Guid dataRoomId, Guid folderId, CreateFileRequest request, CancellationToken cancellationToken)
    {
        var dataroom = await dbContext.DataRooms.Include(dataRoom => dataRoom.Folders).FirstOrDefaultAsync(d => d.Id == dataRoomId, cancellationToken);
        if (dataroom == default)
        {
            // TODO: Create not found exception
            throw new Exception();
        }

        var folder = dataroom.Folders.FirstOrDefault(f => f.Id == folderId);
        if (folder == default)
        {
            // TODO: Create not found exception
            throw new Exception();
        }

        var file = new File
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            FolderId = folderId,
            Base64Content = request.Base64Content
        };
        dbContext.Files.Add(file);
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return file.Id;
    }
    
    public async Task<GenerateDummyFileResponse> GenerateDummyFileAsync(GenerateDummyFileRequest request, CancellationToken cancellationToken)
    {
        var fileName = $"{request.FileName}.txt";
        var generateDummyFileContentPrompt = $"Generate a creative content for the file: {fileName}. No need for further explanation.";
        var fileContent = await llmFacade.GenerateRawResponseAsync(generateDummyFileContentPrompt);
        
        return new GenerateDummyFileResponse
        {
            FileName = fileName,
            FileContent = Encoding.UTF8.GetBytes(fileContent)
        };
    }
}
