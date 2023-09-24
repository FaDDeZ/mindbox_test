import sqlite3 as sl


if __name__ == '__main__':
    con = sl.connect('pc.db')
    sql = 'DELETE from products'
    with con:
        con.execute(sql)
    sql = 'DELETE from category'
    with con:
        con.execute(sql)
    sql = 'DELETE from product_cat'
    with con:
        con.execute(sql)
    data = con.execute("select count(*) from sqlite_master where type='table' and name='products'")
    for row in data:
        if row[0] == 0:
            with con:
                con.execute("""
                    CREATE TABLE products (
                        id_p INTEGER PRIMARY KEY,
                        name VARCHAR(20)
        
                    );
                """)
    sql = 'INSERT INTO products (id_p, name) values(?, ?)'
    data = [
        (1, "T-shirt"),
        (2, "BMW"),
        (3, "Phone")
    ]
    with con:
        con.executemany(sql, data)
    data = con.execute("select count(*) from sqlite_master where type='table' and name='category'")
    for row in data:
        if row[0] == 0:
            with con:
                con.execute("""
                    CREATE TABLE category (
                        id_c INTEGER PRIMARY KEY,
                        name VARCHAR(20)
        
                    );
                """)
    sql = 'INSERT INTO category (id_c, name) values(?, ?)'
    data = [
        (1, "Clothes"),
        (2, "Auto"),
        (3, "Phone")
    ]
    with con:
        con.executemany(sql, data)
    data = con.execute("select count(*) from sqlite_master where type='table' and name='product_cat'")
    for row in data:
        if row[0] == 0:
            with con:
                con.execute("""
                    CREATE TABLE product_cat (
                        id INTEGER PRIMARY KEY,
                        product_id INTEGER,
                        category_id INTEGER,
                        FOREIGN KEY (product_id) REFERENCES products(id),
                        FOREIGN KEY (category_id) REFERENCES category(id)
        
                    );
                """)
    sql = 'INSERT INTO product_cat (id, product_id, category_id) values(?, ?, ?)'
    data = [
        (1, 1, 1),
        (2, 2, 2),
        (3, 3, None)
    ]
    with con:
        con.executemany(sql, data)
    print("Таблица Продуктов")
    with con:
        data = con.execute("SELECT * "
                           "FROM products")
        for row in data:
            print(row)
        print("Таблица категорий")
        data = con.execute("SELECT * "
                           "FROM category")
        for row in data:
            print(row)
        print("Результирующая таблица")
        data = con.execute("SELECT * "
                           "FROM product_cat")
        for row in data:
            print(row)

    #SQL-запрос для задания
    print("Запрос (Продукт-категория)")
    with con:
        data = con.execute("SELECT products.name as product, category.name as category "
                           "FROM products "
                           "LEFT JOIN product_cat ON products.id_p = product_cat.product_id "
                           "LEFT JOIN category ON product_cat.category_id = category.id_c")
        for row in data:
            print(row)
