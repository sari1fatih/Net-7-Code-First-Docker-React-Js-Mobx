using RealEstate.Domain.Entities;

namespace Persistence.Generate
{
    public static class RandomGenerate
    {
        public static List<ProductPhoto> GenerateRandomProductPhotoList()
        {
            List<ProductPhoto> listProductPhotos = new List<ProductPhoto>();

            for (int productId = 1; productId <= 10000; productId++)
            {
                for (int productPhotoId = 1; productPhotoId <= 2; productPhotoId++)
                {
                    listProductPhotos.Add(GenerateRandomProductPhoto(productPhotoId + ((productId -1) * 2), productId));
                }
            }
            return listProductPhotos;
        }

        public static List<Product> GenerateRandomProductList()
        {
            List<Product> listProducts = new List<Product>();
            for (int i = 1; i <= 10000; i++)
            {
                listProducts.Add(GenerateRandomProduct(i));
            }
            return listProducts;
        }
        private static Product GenerateRandomProduct(int id)
        {
            var random = new Random();
            var randomProduct = new Product()
            {
                id = id,
                title = GetRandomTitle(),
                description = GetRandomDescription(),
                totalSquareFootage = random.Next(80, 300),
                price = random.Next(1, 150000),
                propertyTypeEntityId = (short)random.Next(1, 4),
                furnitureConditionEntityId = (short)random.Next(4, 6),
                numberOfRoomsEntityId = (short)random.Next(6, 12),
                floorLevelEntityId = (short)random.Next(12, 19),
                buildingAgeEntityId = (short)random.Next(19, 29)
            };

            return randomProduct;
        }
        private static string GetRandomTitle()
        {
            var titles = new List<string>
            {
                "MUHTEŞEM DENİZ MANZARALI VİLLA",
                "SAHİLE YAKIN LÜKS DAİRE",
                "HUZURLU ŞEHİR EVDEN EVE TAŞINMAYA HAZIR",
                "LÜKS PENTHOUSE DAİRE",
                "ŞEHİR MERKEZİNDE MODERN LOFT",
                "BAHÇELİ MÜSTAKİL EV",
                "DOĞA İLE İÇ İÇE HAVUZLU VİLLA",
                "SUNİ GÖLET MANZARALI DAİRE",
                "YEŞİL BİR CENNETTE KÖY EVİ",
                "ULAŞIMI KOLAY MERKEZİ KONUM",
                "HAVUZLU LÜKS SİTE DAİRESİ",
                "DOĞA İLE BAŞ BAŞA KEYİFLİ YAŞAM",
                "SESSİZ SAKİN DOĞA EVİ",
                "ŞEHİR MANZARALI ÇATI KATI",
                "YEŞİLLİKLER İÇİNDE HUZURLU EV",
                "ULTRA LÜKS REZİDANS DAİRESİ",
                "SOSYAL TESİSLERİ OLAN SİTE DAİRESİ",
                "TAŞ EVİNDE HUZUR BULUN",
                "MERKEZİ KONUMDA TERASLI DAİRE",
                "KUŞ CIVILTI ARASINDA EŞSİZ VİLLA",
                "SAHİLE YÜRÜME MESAFESİNDE DAİRE",
                "YEŞİLLİKLER İÇİNDE SAKİN YAŞAM",
                "LÜKS YAŞAMIN KEYFİNİ ÇIKARIN",
                "ORMAN MANZARALI MUHTEŞEM VİLLA",
                "ULAŞIMI KOLAY ŞEHİR MERKEZİ DAİRE",
                "MARİNA MANZARALI LÜKS DAİRE",
                "YAZ SICAKLARINDA HAVUZ KEYFİ",
                "BAĞ BAHÇE İÇİNDE LÜKS VİLLA",
                "YENİ YAPILI MERKEZİ DAİRE",
                "DOĞAL GÜZELLİKLERE KOMŞU VİLLA"
            };

            var random = new Random();
            return titles[random.Next(titles.Count)];
        }
        private static string GetRandomDescription()
        {
            var descriptions = new List<string>
             {

                "Harika manzaralı muhteşem bir gayrimenkul. Eşsiz doğa ve deniz manzarasına sahip olan bu mülk, lüks ve konforu bir araya getiriyor.",
                "Geniş ve iyi tasarlanmış daire satılık. Ferah iç mekanları ve modern tasarımı ile bu daire aileler için mükemmel bir seçenek.",
                "Huzurlu bir mahallede şirin bir ev. Sessiz ve sakin çevresiyle bu ev, huzurlu bir yaşam tarzını arayanlar için ideal bir tercih.",
                "Zarif penthouse, üstün olanaklarla dolu. Modern ve lüks tasarımıyla bu penthouse yaşam tarzınızı yükseltiyor.",
                "Şehrin kalbinde modern bir loft. Merkezi konumu ve şık tasarımıyla bu loft, şehir hayatının tadını çıkarmak isteyenler için mükemmel bir seçenek.",
                "Deniz kenarında keyifli bir tatil evi. Kumlu plajlara yakın olan bu ev, yaz aylarında huzur dolu bir tatil imkanı sunuyor.",
                "Doğayla iç içe havuzlu bir villa. Muhteşem bahçesi ve özel havuzuyla bu villa, doğal güzelliklerle çevrili lüks bir yaşam sunuyor.",
                "Gölet manzaralı modern bir daire. Doğal güzellikleri iç mekanlara taşıyan bu daire, huzurlu ve sakin bir yaşam sunuyor.",
                "Köy yaşamının keyfini çıkarın. Yeşillikler arasında yer alan bu köy evi, geleneksel ve huzurlu bir yaşam tarzı sunuyor.",
                "Ulaşımı kolay merkezi konum. Şehir merkezine yakın olan bu ev, iş ve sosyal aktivitelere ulaşımı kolaylaştırıyor.",
                "Havuzlu lüks sitede daire. Sosyal olanaklarla donatılmış bu site, lüks ve rahat bir yaşam sunuyor.",
                "Doğa ile iç içe huzurlu bir yaşam. Yeşillikler arasında yer alan bu ev, doğanın tadını çıkarmak isteyenler için mükemmel bir seçenek.",
                "Şık ve modern çatı katı. Şehir manzarası eşliğinde bu çatı katında şık bir yaşamın keyfini çıkarın.",
                "Yeşillikler arasında huzurlu bir ev. Doğanın kucağında yer alan bu ev, stres ve karmaşadan uzak sakin bir yaşam sunuyor.",
                "Lüks rezidans daireleriyle rahat yaşam. Yüksek kaliteli olanaklarla donatılmış bu rezidans, lüks ve konforu bir araya getiriyor.",
                "Sosyal tesislere sahip site içi daire. Havuz, spor alanları ve daha fazlasıyla bu site, sosyal bir yaşam sunuyor.",
                "Doğal taş evinde huzur bulun. Geleneksel mimari ve doğal dokusuyla bu ev, huzurlu bir yaşam tarzı sunuyor.",
                "Merkezi konumda teraslı daire. Şehir merkezine yakın olan bu daire, modern yaşamın konforunu şehir manzarasıyla birleştiriyor.",
                "Kuş cıvıltı arasında eşsiz bir villa. Doğanın içinde yer alan bu villa, huzur dolu bir yaşamın kapılarını açıyor.",
                "Sahile yürüme mesafesinde daire. Plajlara yakın olan bu daire, deniz ve kumun keyfini çıkarmak isteyenlere hitap ediyor.",
                "Yeşillikler içinde sakin bir yaşam. Huzurlu çevresiyle bu ev, doğayla iç içe bir yaşam tarzı sunuyor.",
                "Lüks yaşamın keyfini çıkarın. Yüksek standartlara sahip olan bu ev, lüks ve konforlu bir yaşam sunuyor.",
                "Orman manzaralı muhteşem villa. Doğanın güzellikleri içinde yer alan bu villa, doğal bir yaşamın tadını çıkarmanızı sağlıyor.",
                "Ulaşımı kolay şehir merkezi daire. Şehrin merkezi konumunda olan bu daire, tüm olanaklara kolay erişim sağlıyor.",
                "Marina manzaralı lüks daire. Deniz manzarasıyla bu daire, lüks bir yaşamın anahtarını sunuyor.",
                "Tarihi yarımadada eşsiz bir konak. Tarih ve modern yaşamın buluştuğu bu konak, benzersiz bir deneyim sunuyor.",
                "Dağ manzaralı şirin bir dağ evi. Doğa ile iç içe olan bu ev, huzurlu bir dağ yaşamının kapılarını açıyor.",
                "Göl kenarında romantik bir yazlık. Göle sıfır konumuyla bu yazlık, romantik ve dinlendirici bir tatil sunuyor.",
                "Modern mimarinin örnekleri arasında öne çıkan villa. Yenilikçi tasarımı ve özel özellikleriyle bu villa, şıklık ve lüksü bir araya getiriyor.",
                "Tarihi dokusuyla büyüleyen antika ev. Geçmişin izlerini taşıyan bu ev, nostaljik bir atmosfer sunuyor.",
                "Golf sahasına yakın şık bir konut. Spor ve lüks yaşamı bir araya getiren bu konut, keyif dolu bir yaşam sunuyor.",
                "Deniz manzaralı müstakil bahçeli villa. Özel bahçesi ve muhteşem deniz manzarasıyla bu villa, lüks ve özgürlüğü bir araya getiriyor.",
                "Kültürel mirasa sahip tarihi ev. Geçmişin hikayelerini barındıran bu ev, tarih severler için eşsiz bir seçenek.",
                "Dağların arasında huzurlu bir yaşam. Doğal güzelliklerle çevrili olan bu ev, sakinlik ve huzur arayanlara hitap ediyor.",
                "Modern şehir evidir. Şehir hayatının tüm olanaklarına yakın olan bu ev, şehir yaşamını kolaylaştırıyor.",
                "Lüks ve stilin buluştuğu özel bir rezidans. Yüksek kaliteli malzemelerle inşa edilen bu rezidans, zengin yaşamın kapılarını açıyor.",
                "Bahçeli taş ev. Geleneksel mimariyle tasarlanan bu ev, doğal ve sıcak bir atmosfer sunuyor.",
                "Sanat ve kültürün merkezinde ferah bir daire. Sanat galerileri ve kültürel etkinliklere yakın olan bu daire, sanatseverler için ideal.",
                "Sahile yakın bir tatil köyünde villa. Plajlara yakın olan bu villa, deniz ve güneşin keyfini çıkarmak isteyenlere hitap ediyor.",
                "Modern ve şık bir şehir evi. Şehir merkezine yakın olan bu ev, şehir hayatının konforunu sunuyor.",
                "Göl manzaralı sessiz bir yazlık. Doğal güzelliklerin arasında yer alan bu yazlık, huzurlu bir tatil deneyimi sunuyor.",
                "Güvenli ve nezih bir site içi daire. Sosyal olanaklarla dolu olan bu site, aileler için güvenli ve keyifli bir yaşam sunuyor.",
                "Dağ manzaralı ahşap bir ev. Doğanın kucağında yer alan bu ev, sıcak ve doğal bir yaşam tarzı sunuyor.",
                "Geleneksel köy evi. Köy yaşamının samimi atmosferini hissedeceğiniz bu ev, gerçek bir köy deneyimi sunuyor.",
                "Golf sahasına sıfır modern villa. Spor ve lüksü bir araya getiren bu villa, keyifli bir yaşam sunuyor.",
                "Denize sıfır lüks daire. Plajlara yakın olan bu daire, deniz manzarasının tadını çıkarmanızı sağlıyor.",
                "Marina manzaralı şık bir konut. Deniz ve yat limanı manzarasıyla bu konut, deniz severlere hitap ediyor.",
                "Modern mimarinin şaheseri villa. Estetik ve şıklığın buluştuğu bu villa, lüks bir yaşam sunuyor.",
                "Sessiz ve huzurlu dağ evi. Doğanın kucakladığı bu ev, doğal güzellikler içinde sakin bir yaşam sunuyor.",
                "Havuzlu bahçeli villa. Özel havuzu ve geniş bahçesiyle bu villa, keyifli bir yaşam sunuyor.",
                "Göl manzaralı ahşap kır evi. Geleneksel dokuya sahip bu ev, doğal ve sıcak bir atmosfer sunuyor.",
                "Modern ve rahat bir daire. Şehir yaşamının tüm olanaklarına yakın olan bu daire, konforlu bir yaşam sunuyor.",
                "Göl kenarında tatil köyünde villa. Göle sıfır konumuyla bu villa, göl manzarasının tadını çıkarmanızı sağlıyor.",
                "Yenilenmiş tarihi konak. Tarihi detayları modern olanaklarla birleştiren bu konak, benzersiz bir yaşam sunuyor.",
                "Sahile yakın modern daire. Plajlara yakın olan bu daire, deniz severlere hitap ediyor.",
                "Huzurlu ve doğal bir yaşam. Doğal güzellikler arasında yer alan bu ev, huzurlu bir yaşam tarzı sunuyor.",
                "Modern şehir evidir. Şehir hayatının tüm olanaklarına yakın olan bu ev, şehir yaşamını kolaylaştırıyor.",
                "Lüks ve stilin buluştuğu özel bir rezidans. Yüksek kaliteli malzemelerle inşa edilen bu rezidans, zengin yaşamın kapılarını açıyor.",
                "Bahçeli taş ev. Geleneksel mimariyle tasarlanan bu ev, doğal ve sıcak bir atmosfer sunuyor.",
                "Sanat ve kültürün merkezinde ferah bir daire. Sanat galerileri ve kültürel etkinliklere yakın olan bu daire, sanatseverler için ideal.",
                "Sahile yakın bir tatil köyünde villa. Plajlara yakın olan bu villa, deniz ve güneşin keyfini çıkarmak isteyenlere hitap ediyor.",
                "Modern ve şık bir şehir evi. Şehir merkezine yakın olan bu ev, şehir hayatının konforunu sunuyor.",
                "Göl manzaralı sessiz bir yazlık. Doğal güzelliklerin arasında yer alan bu yazlık, huzurlu bir tatil deneyimi sunuyor.",
                "Güvenli ve nezih bir site içi daire. Sosyal olanaklarla dolu olan bu site, aileler için güvenli ve keyifli bir yaşam sunuyor.",
                "Dağ manzaralı ahşap bir ev. Doğanın kucağında yer alan bu ev, sıcak ve doğal bir yaşam tarzı sunuyor.",
                "Geleneksel köy evi. Köy yaşamının samimi atmosferini hissedeceğiniz bu ev, gerçek bir köy deneyimi sunuyor.",
                "Golf sahasına sıfır modern villa. Spor ve lüksü bir araya getiren bu villa, keyifli bir yaşam sunuyor.",
                "Denize sıfır lüks daire. Plajlara yakın olan bu daire, deniz manzarasının tadını çıkarmanızı sağlıyor.",
                "Marina manzaralı şık bir konut. Deniz ve yat limanı manzarasıyla bu konut, deniz severlere hitap ediyor.",
                "Modern mimarinin şaheseri villa. Estetik ve şıklığın buluştuğu bu villa, lüks bir yaşam sunuyor.",
                "Sessiz ve huzurlu dağ evi. Doğanın kucakladığı bu ev, doğal güzellikler içinde sakin bir yaşam sunuyor.",
                "Havuzlu bahçeli villa. Özel havuzu ve geniş bahçesiyle bu villa, keyifli bir yaşam sunuyor.",
                "Göl manzaralı ahşap kır evi. Geleneksel dokuya sahip bu ev, doğal ve sıcak bir atmosfer sunuyor.",
                "Modern ve rahat bir daire. Şehir yaşamının tüm olanaklarına yakın olan bu daire, konforlu bir yaşam sunuyor.",
                "Göl kenarında tatil köyünde villa. Göle sıfır konumuyla bu villa, göl manzarasının tadını çıkarmanızı sağlıyor.",
                "Yenilenmiş tarihi konak. Tarihi detayları modern olanaklarla birleştiren bu konak, benzersiz bir yaşam sunuyor.",
                "Sahile yakın modern daire. Plajlara yakın olan bu daire, deniz severlere hitap ediyor.",
                "Huzurlu ve doğal bir yaşam. Doğal güzellikler arasında yer alan bu ev, huzurlu bir yaşam tarzı sunuyor.",
                "Göl manzaralı lüks daire. Göle yakın konumu ve lüks tasarımıyla bu daire, göl manzarasının keyfini çıkarıyor.",
                "Modern şehir merkezi daire. Şehir yaşamının tüm imkanlarına yakın olan bu daire, hareketli bir şehir yaşamı sunuyor.",
                "Kırsal alanda sessiz bir çiftlik evi. Doğanın içinde yer alan bu ev, huzurlu bir kırsal yaşam deneyimi sunuyor.",
                "Deniz manzaralı villa. Eşsiz deniz manzarası eşliğinde bu villa, lüks ve doğal güzellikleri bir araya getiriyor.",
                "Lüks tatil köyünde havuzlu villa. Tatil köyünün imkanları ve özel havuzuyla bu villa, keyifli bir tatil sunuyor.",
                "Dağların arasında huzurlu bir yaşam. Doğal güzelliklerle çevrili olan bu ev, sakinlik ve huzur arayanlara hitap ediyor.",
                "Sahile yakın şehir evi. Plajlara ve şehir merkezine yakın olan bu ev, konforlu bir yaşam sunuyor.",
                "Modern tasarımıyla öne çıkan daire. Yenilikçi mimarisi ve şık iç mekanlarıyla bu daire, modern bir yaşam sunuyor.",
                "Göl kenarında romantik bir yazlık. Göle sıfır konumuyla bu yazlık, romantik ve dinlendirici bir tatil sunuyor.",
                "Doğayla iç içe olan ev. Doğal güzelliklerin arasında yer alan bu ev, huzurlu bir yaşam tarzı sunuyor.",
                "Modern şehir evidir. Şehir hayatının tüm olanaklarına yakın olan bu ev, şehir yaşamını kolaylaştırıyor.",
                "Lüks ve stilin buluştuğu özel bir rezidans. Yüksek kaliteli malzemelerle inşa edilen bu rezidans, zengin yaşamın kapılarını açıyor.",
                "Bahçeli taş ev. Geleneksel mimariyle tasarlanan bu ev, doğal ve sıcak bir atmosfer sunuyor.",
                "Sanat ve kültürün merkezinde ferah bir daire. Sanat galerileri ve kültürel etkinliklere yakın olan bu daire, sanatseverler için ideal.",
                "Sahile yakın bir tatil köyünde villa. Plajlara yakın olan bu villa, deniz ve güneşin keyfini çıkarmak isteyenlere hitap ediyor.",
                "Modern ve şık bir şehir evi. Şehir merkezine yakın olan bu ev, şehir hayatının konforunu sunuyor.",
                "Göl manzaralı sessiz bir yazlık. Doğal güzelliklerin arasında yer alan bu yazlık, huzurlu bir tatil deneyimi sunuyor.",
                "Güvenli ve nezih bir site içi daire. Sosyal olanaklarla dolu olan bu site, aileler için güvenli ve keyifli bir yaşam sunuyor.",
                "Dağ manzaralı ahşap bir ev. Doğanın kucağında yer alan bu ev, sıcak ve doğal bir yaşam tarzı sunuyor.",
                "Geleneksel köy evi. Köy yaşamının samimi atmosferini hissedeceğiniz bu ev, gerçek bir köy deneyimi sunuyor.",
                "Golf sahasına sıfır modern villa. Spor ve lüksü bir araya getiren bu villa, keyifli bir yaşam sunuyor.",
                "Denize sıfır lüks daire. Plajlara yakın olan bu daire, deniz manzarasının tadını çıkarmanızı sağlıyor."
             };

            var random = new Random();
            return descriptions[random.Next(descriptions.Count)];
        }

        private static string GetProductPhotoUrl()
        {
            var titles = new List<string>
            {
                "https://i0.shbdn.com/photos/00/94/85/x5_1114009485gpf.jpg",
                "https://i0.shbdn.com/photos/00/94/85/x5_1114009485ouw.jpg",
                "https://i0.shbdn.com/photos/00/94/85/x5_11140094857va.jpg",
                "https://i0.shbdn.com/photos/90/34/02/x5_11139034025hk.jpg",
                "https://i0.shbdn.com/photos/96/92/51/x5_10999692513u4.jpg",
                "https://i0.shbdn.com/photos/96/92/51/x5_1099969251buf.jpg",
                "https://i0.shbdn.com/photos/96/92/51/x5_1099969251049.jpg",
                "https://i0.shbdn.com/photos/96/92/51/x5_10999692518nu.jpg",
                "https://i0.shbdn.com/photos/84/80/40/x5_1101848040sjl.jpg",
                "https://i0.shbdn.com/photos/84/80/40/x5_1101848040ute.jpg"
            };

            var random = new Random();
            return titles[random.Next(titles.Count)];
        }

        private static ProductPhoto GenerateRandomProductPhoto(int id, int productId)
        {
            var randomProduct = new ProductPhoto()
            {
                id = id,
                productId = productId,
                url = GetProductPhotoUrl()
            };

            return randomProduct;
        }
    }
}

