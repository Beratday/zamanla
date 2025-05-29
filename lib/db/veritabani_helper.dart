// lib/db/veritabani_helper.dart

import 'package:sqflite/sqflite.dart';
import 'package:path/path.dart';

class VeritabaniHelper {
  static final VeritabaniHelper _instance = VeritabaniHelper._internal();
  factory VeritabaniHelper() => _instance;
  VeritabaniHelper._internal();

  static Database? _database;

  Future<Database> get database async {
    if (_database != null) return _database!;
    _database = await _initDb();
    return _database!;
  }

  Future<Database> _initDb() async {
    String dbPath = await getDatabasesPath();
    String path = join(dbPath, 'zamanla.db');

    return await openDatabase(
      path,
      version: 1,
      onCreate: (db, version) async {
        await db.execute('''
          CREATE TABLE randevu(
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            baslik TEXT,
            tarih TEXT
          )
        ''');
      },
    );
  }

  Future<int> insertRandevu(Map<String, dynamic> randevu) async {
    final db = await database;
    return await db.insert('randevu', randevu);
  }

  Future<List<Map<String, dynamic>>> getRandevular() async {
    final db = await database;
    return await db.query('randevu');
  }

  // Diðer DB fonksiyonlarýný ekleyebilirsin
}
