﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ContactList.DDD.Domain.Entities;
using ContactList.DDD.Domain.ValueObjects;
using ContactList.DDD.Domain.Repositories;

namespace ContactList.DDD.Infrastructure
{
    public class ContactRepository:IContactRepository
    {

        public async Task<IEnumerable<Contact>> GetAllContacts()
        {
            List<Contact> contacts = new List<Contact>();

            using (SqlConnection connection = new SqlConnection(DatabaseContext.connRute))
            {
                SqlCommand cmd = new SqlCommand("GetAllContacts", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    await connection.OpenAsync();

                    using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                    {
                        while (await dr.ReadAsync())
                        {
                            contacts.Add(new Contact()
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Name = ContactName.Create(dr["Name"].ToString()),
                                LastName = ContactLastName.Create(dr["LastName"].ToString()),
                                Cellphone = ContactCellphone.Create(dr["Cellphone"].ToString()),
                                Email = ContactEmail.Create(dr["Email"].ToString()),
                                dateOfRegistration = Convert.ToDateTime(dr["dateOfRegistration"].ToString())
                            });
                        }
                    }

                    return  contacts;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return contacts;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        

        public async Task<IEnumerable<Contact>> GetContactsPerPage(int PageNumber, string Order, string OrderBy)
        {
            List<Contact> contacts = new List<Contact>();

            using (SqlConnection connection = new SqlConnection(DatabaseContext.connRute))
            {
                SqlCommand cmd = new SqlCommand("GetContactsPerPage", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PageNumber", PageNumber);
                cmd.Parameters.AddWithValue("@Order", Order);
                cmd.Parameters.AddWithValue("@OrderBy", OrderBy);
                try
                {
                    await connection.OpenAsync();

                    using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                    {
                        while (await dr.ReadAsync())
                        {
                            contacts.Add(new Contact()
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Name = ContactName.Create(dr["Name"].ToString()),
                                LastName = ContactLastName.Create(dr["LastName"].ToString()),
                                Cellphone = ContactCellphone.Create(dr["Cellphone"].ToString()),
                                Email = ContactEmail.Create(dr["Email"].ToString()),
                                dateOfRegistration = Convert.ToDateTime(dr["dateOfRegistration"].ToString())
                            });
                        }
                    }

                    return contacts;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return contacts;
                }
                finally
                {
                    connection.Close();
                }
            }
        }


        public async Task<IEnumerable<Contact>> SearchContactsPerPage(int PageNumber, string SearchTerm, string Order, string OrderBy)
        {
            List<Contact> contacts = new List<Contact>();

            using (SqlConnection connection = new SqlConnection(DatabaseContext.connRute))
            {
                SqlCommand cmd = new SqlCommand("SearchContactsPerPage", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PageNumber", PageNumber);
                cmd.Parameters.AddWithValue("@Order", Order);
                cmd.Parameters.AddWithValue("@SearchTerm", SearchTerm);
                cmd.Parameters.AddWithValue("@OrderBy", OrderBy);

                try
                {
                    await connection.OpenAsync();

                    using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                    {
                        while (await dr.ReadAsync())
                        {
                            contacts.Add(new Contact()
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Name = ContactName.Create(dr["Name"].ToString()),
                                LastName = ContactLastName.Create(dr["LastName"].ToString()),
                                Cellphone = ContactCellphone.Create(dr["Cellphone"].ToString()),
                                Email = ContactEmail.Create(dr["Email"].ToString()),
                                dateOfRegistration = Convert.ToDateTime(dr["dateOfRegistration"].ToString())
                            });
                        }
                    }

                    return contacts;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return contacts;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public async Task<Contact> GetContactById(int id)
        {
            Contact contact = new Contact();

            using (SqlConnection connection = new SqlConnection(DatabaseContext.connRute))
            {
                SqlCommand cmd = new SqlCommand("GetContactById", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                try
                {
                    await connection.OpenAsync();

                    using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                    {
                        while (await dr.ReadAsync())
                        {
                            contact = new Contact()
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Name = ContactName.Create(dr["Name"].ToString()),
                                LastName = ContactLastName.Create(dr["LastName"].ToString()),
                                Cellphone = ContactCellphone.Create(dr["Cellphone"].ToString()),
                                Email = ContactEmail.Create(dr["Email"].ToString()),
                                dateOfRegistration = Convert.ToDateTime(dr["dateOfRegistration"].ToString())
                            };
                        }
                    }

                    return contact;
                }
                catch (Exception ex)
                {
                    return contact;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public async Task<Boolean> DeleteContact(int id)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseContext.connRute))
            {
                SqlCommand cmd = new SqlCommand("DeleteContact", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                try
                {
                    await connection.OpenAsync();
                   await cmd.ExecuteNonQueryAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public async Task<Boolean> InsertContact(Contact contact)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseContext.connRute))
            {
                SqlCommand cmd = new SqlCommand("InsertContact", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", contact.Name);
                cmd.Parameters.AddWithValue("@LastName", contact.LastName);
                cmd.Parameters.AddWithValue("@Cellphone", contact.Cellphone);
                cmd.Parameters.AddWithValue("@Email", contact.Email);

                try
                {
                    await connection.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public async Task<Boolean> UpdateContact(Contact contact)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseContext.connRute))
            {
                SqlCommand cmd = new SqlCommand("UpdateContact", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", contact.Id);
                cmd.Parameters.AddWithValue("@Name", contact.Name);
                cmd.Parameters.AddWithValue("@LastName", contact.LastName);
                cmd.Parameters.AddWithValue("@Cellphone", contact.Cellphone);
                cmd.Parameters.AddWithValue("@Email", contact.Email);

                try
                {
                    await connection.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        
    }
}
