class Randevu {
  int? id;
  String baslik;
  DateTime tarih;

  Randevu({this.id, required this.baslik, required this.tarih});

  Map<String, dynamic> toMap() {
    return {
      'id': id,
      'baslik': baslik,
      'tarih': tarih.toIso8601String(),
    };
  }

  factory Randevu.fromMap(Map<String, dynamic> map) {
    return Randevu(
      id: map['id'],
      baslik: map['baslik'],
      tarih: DateTime.parse(map['tarih']),
    );
  }
}
