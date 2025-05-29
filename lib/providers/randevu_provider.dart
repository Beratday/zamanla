import 'package:flutter/material.dart';
import '../models/randevu.dart';
import '../db/veritabani_helper.dart';

class RandevuProvider with ChangeNotifier {
  List<Randevu> _randevular = [];

  List<Randevu> get randevular => _randevular;

  Future<void> yukleRandevular() async {
    _randevular = await VeritabaniHelper().getRandevular();
    notifyListeners();
  }

  Future<void> randevuEkle(Randevu r) async {
    await VeritabaniHelper().ekleRandevu(r);
    await yukleRandevular();
  }

  Future<void> randevuSil(int id) async {
    await VeritabaniHelper().silRandevu(id);
    await yukleRandevular();
  }
}
