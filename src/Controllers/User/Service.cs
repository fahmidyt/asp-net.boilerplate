using User.Models;

namespace User.Service;

public static class UserService {
  static List<UserModel> Users { get; }

  static UserService() {
    Users = new List<UserModel> {
      new UserModel { Id = 1, Name = "Muhammad Fahmi", Active = true, Password="admin123" },
      new UserModel { Id = 2, Name = "Hidayat", Active = true, Password="admin123" }
    };
  }

  public static List<UserModel> GetAll() => Users;

  public static UserModel? Get(int id) => Users.FirstOrDefault(obj => obj.Id == id);

  public static void Add(UserModel user) {
    int nextId = Users.Count + 1;
    user.Id = nextId;
    Users.Add(user);
  }

  public static void Delete(int id) {
    var user = Get(id);

    if (user is null) return;

    Users.Remove(user);
  }

  public static void Update(int id, UserModel data) {
    var user = Get(id);
    
    if (user is null) return;

    data.Id = user.Id;
    var userIdx = Users.FindIndex(obj => obj.Id == data.Id);

    if (userIdx == -1) return;

    Users[userIdx] = data;
  }
}