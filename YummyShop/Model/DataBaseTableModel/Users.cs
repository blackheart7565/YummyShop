﻿namespace YummyShop.Model.DataBaseTableModel {
    public class Users {
        public int Id { get; set; }
        public string? FirstName { get; set; } = null;
        public string? LastName { get; set; }= null;
        public string? Username { get; set; }= null; 
        public string? Password { get; set; } = null;
        public string? Email { get; set; }= null;
        public string? Phone { get; set; } = null;
    }
}
