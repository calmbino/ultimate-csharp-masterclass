namespace GameDataParser.Model;

public class GameData
{
    // 파일로부터 읽은 객체를 수정할 일이 없으므로 set은 불필요.
    public required string Title { get; init; }
    public required int ReleaseYear { get; init; }
    public required decimal Rating { get; init; }
        
    public override string ToString() => $"{Title}, released in {ReleaseYear}, rating: {Rating}";
}