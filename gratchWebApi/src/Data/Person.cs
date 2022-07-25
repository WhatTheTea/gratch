namespace gratch.Api.Data
{
    public record PersonModel(
        int Id,
        int GroupId,
        GroupModel Group,
        int Position 
        );
}