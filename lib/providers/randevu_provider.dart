// lib/providers/randevu_provider.dart

import 'package:flutter/material.dart';
import 'package:zamanla/db/veritabani_helper.dart';  // Doðru import yolu

class RandevuProvider with ChangeNotifier {
  final VeritabaniHelper _dbHelper = VeritabaniHelper();

  List<Map<String, dynamic>> _randevular = [];

  List<Map<String, dynamic>> get randevular => _randevular;

  Future<void> fetchRandevular() async {
    _randevular = await _dbHelper.getRandevular();
    notifyListeners();
  }

  Future<void> addRandevu(Map<String, dynamic> randevu) async {
    await _dbHelper.insertRandevu(randevu);
    await fetchRandevular();
  }


}
