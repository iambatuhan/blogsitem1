// JavaScript
// Three.js kütüphanesini projemize dahil ediyoruz.
// Not: Bu örnek için Three.js'in CDN bağlantısını kullanıyoruz.
// Daha güncel bir versiyon veya farklı yükleme yöntemleri için Three.js'in resmi sitesine göz atabilirsiniz.
// https://threejs.org/
import * as THREE from 'https://cdnjs.cloudflare.com/ajax/libs/three.js/r128/three.min.js';

// Renderer oluşturuyoruz.
const renderer = new THREE.WebGLRenderer();
renderer.setSize(window.innerWidth, window.innerHeight);
document.body.appendChild(renderer.domElement);

// Scene oluşturuyoruz.
const scene = new THREE.Scene();

// Kamera oluşturuyoruz.
const camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);
camera.position.z = 5;

// Geometri oluşturuyoruz (örneğin bir küp).
const geometry = new THREE.BoxGeometry();
const material = new THREE.MeshBasicMaterial({ color: 0x00ff00 });
const cube = new THREE.Mesh(geometry, material);
scene.add(cube);

// Render fonksiyonu oluşturuyoruz.
function animate() {
    requestAnimationFrame(animate);

    // Küpü döndürme animasyonu ekliyoruz.
    cube.rotation.x += 0.01;
    cube.rotation.y += 0.01;

    // Sahneyi render ediyoruz.
    renderer.render(scene, camera);
}
animate();
