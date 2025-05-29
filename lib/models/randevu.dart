class Randevu {
  final int? id;
  final String baslik;
  final String aciklama;
  final String tarih;

  Randevu({
    this.id,
    required this.baslik,
    required this.aciklama,
    required this.tarih,
  });

  Map<String, dynamic> toMap() {
    return {
      'id': id,
      'baslik': baslik,
      'aciklama': aciklama,
      'tarih': tarih,
    };
  }

  factory Randevu.fromMap(Map<String, dynamic> map) {
    return Randevu(
      id: map['id'],
      baslik: map['baslik'],
      aciklama: map['aciklama'],
      tarih: map['tarih'],
    );
  }
}
