import 'package:sqflite/sqflite.dart';
import 'package:path/path.dart';
import '../models/randevu.dart';

class VeritabaniHelper {
  static final VeritabaniHelper _instance = VeritabaniHelper._internal();
  factory VeritabaniHelper() => _instance;
  VeritabaniHelper._internal();

  static Database? _db;

  Future<Database> get database async {
    if (_db != null) return _db!;
    _db = await _initDB();
    return _db!;
  }

  Future<Database> _initDB() async {
    String path = join(await getDatabasesPath(), 'randevular.db');
    return await openDatabase(path, version: 1, onCreate: _onCreate);
  }

  Future _onCreate(Database db, int version) async {
    await db.execute('''
      CREATE TABLE randevular(
        id INTEGER PRIMARY KEY AUTOINCREMENT,
        baslik TEXT,
        aciklama TEXT,
        tarih TEXT
      )
    ''');
  }

  Future<int> ekleRandevu(Randevu r) async {
    final db = await database;
    return await db.insert('randevular', r.toMap());
  }

  Future<List<Randevu>> getRandevular() async {
    final db = await database;
    var result = await db.query('randevular', orderBy: 'tarih DESC');
    return result.map((e) => Randevu.fromMap(e)).toList();
  }

  Future<int> silRandevu(int id) async {
    final db = await database;
    return await db.delete('randevular', where: 'id = ?', whereArgs: [id]);
  }
}
