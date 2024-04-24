/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> } 
 */
exports.seed = async function(knex) {
  // Deletes ALL existing entries
  await knex('users').del()
  await knex('users').insert([
    {id: 1, first_name: "firstname", last_name: 'rowValue1'},
    {id: 2, first_name: "firstname", last_name: 'rowValue2'},
    {id: 3, first_name: "firstname", last_name: 'rowValue3'}
  ]);
};
