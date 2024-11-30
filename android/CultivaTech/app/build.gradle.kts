plugins {
    alias(libs.plugins.android.application)
}

android {
    namespace = "com.unip.cultivatech"
    compileSdk = 34

    defaultConfig {
        applicationId = "com.unip.cultivatech"
        minSdk = 28
        targetSdk = 34
        versionCode = 1
        versionName = "1.0"

        testInstrumentationRunner = "androidx.test.runner.AndroidJUnitRunner"
    }

    buildTypes {
        release {
            isMinifyEnabled = false
            proguardFiles(
                getDefaultProguardFile("proguard-android-optimize.txt"),
                "proguard-rules.pro"
            )
        }
    }

    compileOptions {
        sourceCompatibility = JavaVersion.VERSION_1_8
        targetCompatibility = JavaVersion.VERSION_1_8
    }


}

dependencies {

    // Biblioteca de interface e outras dependências do Android
    implementation(libs.appcompat)
    implementation(libs.material)
    implementation(libs.activity)
    implementation(libs.constraintlayout)

    // Testing dependencies
    testImplementation(libs.junit)
    androidTestImplementation(libs.ext.junit)
    androidTestImplementation(libs.espresso.core)

    // Room Database
    implementation("androidx.room:room-runtime:2.5.1")  // Para a implementação do Room
    implementation("androidx.room:room-ktx:2.5.1")    // Para suporte a Kotlin Extensions (Coroutines)

    // Glide para carregamento de imagens
    implementation("com.github.bumptech.glide:glide:4.15.1")
    annotationProcessor("androidx.room:room-compiler:2.5.1") // Usando annotationProcessor para gerar o código em Java

    // Kotlin dependencies
    implementation("org.jetbrains.kotlin:kotlin-stdlib:1.8.10")

    // Android Lifecycle dependencies
    implementation("androidx.lifecycle:lifecycle-runtime-ktx:2.6.1")

    implementation("androidx.appcompat:appcompat:1.4.0")
    implementation("androidx.constraintlayout:constraintlayout:2.1.0")

    // Testing dependencies for Room
    testImplementation("androidx.room:room-testing:2.5.1")
}
